using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrollerController : MonoBehaviour {

	[Header("Speed variables")]
	public float scrollSpeed = 1;
	public float bgParallaxAmount;
	public float fgParllaxAmount;

	[Header("different visible layers")]
	public List <GameObject> mgObjects;
	public List <GameObject> fgObjects;
	public List <GameObject> bgObjects;
	public List <GameObject> bgObjects2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		foreach(GameObject thisObj in mgObjects)
		{
			if (thisObj) {
				float newX = thisObj.transform.position.x - (scrollSpeed * Time.deltaTime);
				thisObj.transform.position = new Vector3(newX, thisObj.transform.position.y, thisObj.transform.position.z);
			}
		}

		foreach(GameObject thisObj in bgObjects)
		{
			if (thisObj) {

				float newX = thisObj.transform.position.x;

				if (newX <= -2)
				{
					newX += 25;
				}

				newX -= scrollSpeed * Time.deltaTime * bgParallaxAmount;

				thisObj.transform.position = new Vector3(newX, thisObj.transform.position.y, thisObj.transform.position.z);
			}
		}

		foreach(GameObject thisObj in fgObjects)
		{
			if (thisObj) {
				float newX = thisObj.transform.position.x - (scrollSpeed * Time.deltaTime * fgParllaxAmount);

				if (newX <= -10)
				{
					newX += Random.Range(40,100);
				}

				thisObj.transform.position = new Vector3(newX, thisObj.transform.position.y, thisObj.transform.position.z);
			}
		}
	}
}
