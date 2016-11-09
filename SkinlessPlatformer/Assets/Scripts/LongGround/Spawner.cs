using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public ScrollerController controller;
	public GameObject[] thingsToSpawn;
	public float spawnMin = 1f;
	public float spawnMax = 2f;

	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn() {

		//Instantiates a random object from the array "thingsToSpawn", which we've filled with our enemy prefabs in the inspector.

		GameObject newObject = Instantiate(thingsToSpawn[Random.Range(0,thingsToSpawn.Length)], transform.position, Quaternion.identity) as GameObject;
		controller.mgObjects.Add(newObject);
		//Invoke is going to tell this function to call itself again, sometime between the minimum and maximum spawn times we've entered.
		Invoke("Spawn", Random.Range(spawnMin,spawnMax));
	}

}
