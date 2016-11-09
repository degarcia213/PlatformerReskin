using UnityEngine;
using System.Collections;

public class StarSpawner : MonoBehaviour {

	public GameObject star;
	public ScrollerController controller;

	//minimum and maximum wait time between spawn.
	public float spawnMin;
	public float spawnMax;

	// Use this for initialization
	void Start () {
		Spawn();
	}


	void Spawn(){
		GameObject newStar = Instantiate(star, transform.position, Quaternion.identity) as GameObject;
		controller.mgObjects.Add(newStar);
		Invoke("Spawn",Random.Range(spawnMin,spawnMax));
	}
}
