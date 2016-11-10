using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[Header("For Checking Ground Collision")]
	public Transform topLeft;
	public Transform bottomRight;
	public LayerMask groundLayer;
	public LayerMask enemyLayer;
	bool onGround = false;
	bool doubleJump = false;
	public bool canDoubleJump;


	Rigidbody2D myBody;

	private Vector3 world;
	private float halfSize;


	[Header("Movement Variables")]
	public float jumpStrength;
	public float xSpeed;
	private float currentXSpeed;

	private bool dead = false;

	private Animator animator;
	private GameController gameController;

	// Use this for initialization
	void Start () {
	
		myBody = GetComponent<Rigidbody2D>();
		myBody.velocity = new Vector2(0, 0);
		animator = GetComponent<Animator>();
		gameController = GameObject.FindObjectOfType<GameController>();

		//getting screen size and player size for bounds locking
		world = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
		halfSize = GetComponent<SpriteRenderer>().bounds.size.x/2;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!dead) {
			//here's what happens when you press either A or Left
			if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {

				//set our current speed to our speed variable in the left direction (negative).
				currentXSpeed = -xSpeed;

				//ensure sprite faces left
				Vector3 myScale = new Vector3(-1,1,1);
				transform.localScale = myScale;
			}
			//here's D or right
			if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {

				//set our current speed to our speed variable in the right direction (positive).
				currentXSpeed = xSpeed;

				//ensure sprite faces right
				Vector3 myScale = new Vector3(1,1,1);
				transform.localScale = myScale;
			}

			//resetting speed to 0 when we release keys
			if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) {
				if (currentXSpeed < 0) {
					currentXSpeed = 0;
				}
			}
			if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) {
				if (currentXSpeed > 0) {
					currentXSpeed = 0;
				}

			}


			//resetting our double jump when we land, and making sure we aren't playing the jump animation anymore.
			if (onGround) {
				doubleJump = false;

				if (currentXSpeed == 0)
				{
					animator.Play("playerIdle");
				} else {
					//animator.Play("playerWalk");
					animator.Play("frogWalk");
				}
			}


			//kill player if you fall off back or bottom of screen.
			if (transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(-1, 0.0f, 0.0f)).x) {
				Die();
			} else if (transform.position.x > world.x - halfSize) {
				Vector3 newPos = new Vector3(world.x - halfSize, transform.position.y, transform.position.z);
				transform.position = newPos;
			}

			if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).y) {
				Die();
			}





			myBody.velocity = new Vector2(currentXSpeed, myBody.velocity.y);

			//here's how we can jump by pressing either up, W, or space bar. We can jump as long as we're on the ground, or doubleJump is set to false. If we jump in the air, we set double jump to true.
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
				if (onGround || (canDoubleJump && !doubleJump)) {
					Jump();
				}
			}
		} else {

		}
	}

	// called once every physics step
	void FixedUpdate() {
		//checing to see if there's a ground tile in the area defined below us by the overlap area gameobjects (you can reposition these -- they're parented under the player object)
		if (Physics2D.OverlapArea(topLeft.position, bottomRight.position, groundLayer) && myBody.velocity.y <= 0){
			onGround = true;
		}
	}

	void Jump(){

			if (!onGround){
				doubleJump = true;
			}
			myBody.velocity = new Vector2(currentXSpeed, jumpStrength);
			animator.Play("playerJump", -1, 0);
			onGround = false;
	}

	//currently called at the end of the player's death animation -- this tells the game controller to go to the game over screen.
	public void communicateDeath()
	{
		gameController.EndGame();
	}

	void Die()
	{
		dead = true;
		Debug.Log("died");
		animator.Play("playerDeath");
		currentXSpeed = 0;
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (!dead){
			if (other.tag == "powerup") {

				Debug.Log("You got a star.");
				gameController.stars += 1;
				Destroy(other.gameObject);
				return;

			} else if (other.tag == "attackBox") {
				Die();
				return;

			} else if (other.tag == "deathBox") {
				
				if (other.transform.parent && other.transform.parent.gameObject.tag == "Enemy"){
					Enemy thisEnemy = other.transform.parent.gameObject.GetComponent<Enemy>();
					thisEnemy.killEnemy();
					gameController.totalBonks += 1;
					Jump();
					doubleJump = false;
					return;
				}
			}
		}
	}
}
