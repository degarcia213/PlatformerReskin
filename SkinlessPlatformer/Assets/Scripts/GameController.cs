using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	enum GameState{
		starting,
		running,
		paused
	}

	private GameState gameState;

	public Player player;
	public ScrollerController scroller;

	[Header("Score Tracking")]
	public float distBuffer = 0;
	public int distDisplay = 0;

	public float totalBonks = 0;

	public float stars = 0;

	[Header("UI Text Boxes")]
	public Text distanceText;
	public Text bonkDisplay;
	public Text starDisplay;


	// this is going to keep our game controller from being destroyed.
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);


		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		gameState = GameState.running;
	}

	void RunGame()
	{


	}

	public void EndGame() {

		distanceText.enabled = false;
		bonkDisplay.enabled = false;
		starDisplay.enabled = false;
		SceneManager.LoadScene(2);

	}
	
	// Update is called once per frame
	void Update () {


		if (gameState == GameState.running)
		{
			//first, let's calculate the distance to the decimal using our float buffer:
			distBuffer += Time.deltaTime;
			//then we'll set the display value to the interger value
			distDisplay = (int)distBuffer;

		}

		//now we'll display the text for each category we have. ToSring converts non-string values to strings, and we append with "+".
		distanceText.text = "Distance Travelled: " + distDisplay.ToString();
		bonkDisplay.text = "Enemies Bonked: " + totalBonks.ToString();
		starDisplay.text = "Stars: " + stars.ToString();

		//let's reset the game if we pres the "r" key
		if (Input.GetKeyDown(KeyCode.R)) {
			RestartGame();
		}


	}

	public void RestartGame() {
		distBuffer = 0;
		distDisplay = 0;
		totalBonks = 0;
		stars = 0;
		SceneManager.LoadScene(1);
		distanceText.enabled = true;
		bonkDisplay.enabled = true;
		starDisplay.enabled = true;
	}
}
