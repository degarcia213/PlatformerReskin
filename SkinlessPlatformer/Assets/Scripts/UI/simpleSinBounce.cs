using UnityEngine;
using System.Collections;

public class simpleSinBounce : MonoBehaviour {

	[Header("vertical wobble/bounce")]
	public float amplitudeY;
	public float omegaY;
	public bool hardBounce;

	[Header("horizontal wobble")]
	public float amplitudeX;
	public float omegaX;

	[Header("rotational wobble")]
	public float amplitudeRot;
	public float omegaRot;

	float index;



	private Vector3 originalPos;

	// Use this for initialization
	void Start () {
		index = 0;
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		index += Time.deltaTime;

		float x = amplitudeX * Mathf.Cos(omegaX * index);
		float y = amplitudeY*Mathf.Sin(omegaY*index);

		if (hardBounce) y = Mathf.Abs(y);

		transform.position = new Vector3(originalPos.x + x, originalPos.y + y, transform.position.z);

		float newRot = amplitudeRot * Mathf.Cos(omegaRot * index) / 100;
		transform.Rotate(0,0,newRot);
	
	}
}
