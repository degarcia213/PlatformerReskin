using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float rotSpeed;
	protected float _speed;
	public float speed {

		get {
			return _speed;
		}

		set {

			_speed = value;
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//rotate for fun! you can change the speed to 0 if you don't want this (you prob don't).
		transform.RotateAround(transform.position,transform.forward,rotSpeed);

		//moving according to the speed variable, which is set in the enemy.
		Vector3 myPos = transform.position;
		myPos.x -= _speed * Time.deltaTime;
		transform.position = myPos;

	}
}
