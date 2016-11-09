using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public bool dying = false;
	private Animator animator;
	private Rigidbody2D body;


	[Header("Harder Enemies")]
	// you guessed it -- set this to true in the inspector?
	// your enemy's gonna jump.
	public bool jumper;
	public float jumpStrength;
	public float jumpDelayMin;
	public float jumpDelayMax;

	[Header("")]
	public GameObject bullet;
	public bool shooter;
	public float shootForce;
	public float shootDelayMin;
	public float shootDelayMax;



	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		body = GetComponent<Rigidbody2D>();

		if (jumper)
		{
			Jump();
		}

		if (shooter)
		{
			Shoot();
		}
	}

	void Shoot(){
		Bullet newBul = (Instantiate(bullet, transform.position, Quaternion.identity) as GameObject).GetComponent<Bullet>();
		newBul.speed = 10;
		Invoke("Shoot",Random.Range(shootDelayMin,shootDelayMax));
	}
		
	void Jump(){
		Vector2 mySpeed = new Vector2(0,jumpStrength);
		body.velocity = mySpeed;
		Invoke("Jump",Random.Range(jumpDelayMin,jumpDelayMax));
	}

	public void killEnemy() {
		dying = true;
		animator.Play("enemyDeath");
	}

	public void die(){
		Destroy(this.gameObject);
	}
}
