using UnityEngine;
using System.Collections;

public class GroundTile : MonoBehaviour {
	//this is an array of all of the sprites we can assign to a ground object
	public Sprite[] possibleSprites;

	// Use this for initialization
	void Start () {

		PickRandomSprite();

	}

	public void PickRandomSprite()
	{
		float randomizer = Random.Range(0f,1f);
		if (randomizer < .75)
		{
			GetComponent<SpriteRenderer>().sprite = possibleSprites[0];
		} else {
			GetComponent<SpriteRenderer>().sprite = possibleSprites[Random.Range(1, possibleSprites.Length)];
		}
	}
}