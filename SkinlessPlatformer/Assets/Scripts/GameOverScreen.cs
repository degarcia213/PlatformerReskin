using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

	private GameController controller;

	public Text scoreDisplay;

	// Use this for initialization
	void Start () {
		// finding our game controller object so we can reset the game from here ;)
		controller = GameObject.FindObjectOfType<GameController>();

		//setting our score display to read the number of stars collected. you could alternatively choose to use bonks or distance!
		// you'd have to change the variable below from stars to totalBonks or distDisplay.
		scoreDisplay.text = "Final Score: " +  controller.stars.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		//if we press spacebar, we call the game controller's reset function. 
		//You can look at that in the Game Controller script. If there's no game controller, we just load the title screen.
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (controller){
				controller.RestartGame();
			} else {
				SceneManager.LoadScene(0);
			}
		}
	}
}
