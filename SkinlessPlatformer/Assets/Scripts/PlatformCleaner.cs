using UnityEngine;
using System.Collections;

public class PlatformCleaner : MonoBehaviour {

	public ScrollerController controller;

	void OnTriggerEnter2D(Collider2D other){

		//if a ground tile hits the cleaner, move it 20 units to the right (aka 20 tiles), and pick a random sprite.
		//if it's an enemy, destroy it. We're done with that one!
		if (other.tag == "Ground")
		{
			float newX = other.transform.position.x + 20;
			other.transform.position = new Vector3(newX,0,0);
			GroundTile newGround = other.transform.GetComponent<GroundTile>();
			newGround.PickRandomSprite();
		} else if (other.tag == "Enemy") {
			controller.mgObjects.Remove(other.transform.gameObject);
			Destroy(other.gameObject);
		} else if (other.tag == "Platform") {
			controller.mgObjects.Remove(other.transform.gameObject);
			Destroy(other.gameObject);
		}
	} 
}
