using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour {

	public float shakeTimer;
	public float shakeAmount;
	private Vector3 originalPos;

	void Start(){
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (shakeTimer >= 0)
		{
			Vector2 shakePos = Random.insideUnitCircle * shakeAmount;

			transform.position = new Vector3(originalPos.x + shakePos.x, originalPos.y + shakePos.y, transform.position.z);

			shakeTimer -= Time.deltaTime;

		} else {

			transform.position = Vector3.Lerp(transform.position, originalPos, .2f);

		}
	
	}

	public void ShakeCamera(float _shakePower, float _shakeDuration) 
	{
		shakeAmount = _shakePower;
		shakeTimer = _shakeDuration;
	}
}
