using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

	public ScrollerController controller;
	public GameObject[] platformTypes;
	public float spawnMin = 1f;
	public float spawnMax = 2f;

	[Header("Enemy Spawning Optional!")]
	public bool spawnsEnemies;
	public float spawnChance; // this is the chance you will spawn an enemy, where 1 = 100 percent.
	public GameObject[] enemies;

	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn()
	{

		GameObject newPlat = Instantiate(platformTypes[Random.Range(0,platformTypes.GetLength(0))], transform.position, Quaternion.identity) as GameObject;
		controller.mgObjects.Add(newPlat);

		if (spawnsEnemies){
			float myChance = Random.Range(0,1);
			if (myChance <= spawnChance)
			{
				Vector3 enemySpawnPos = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z); 
				GameObject newEnemy = Instantiate(enemies[Random.Range(0,enemies.GetLength(0))], enemySpawnPos, Quaternion.identity) as GameObject;
				controller.mgObjects.Add(newEnemy);
			}
		}


		Invoke("Spawn",Random.Range(spawnMin,spawnMax));
	}
}
