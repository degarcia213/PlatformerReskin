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
	}
}
