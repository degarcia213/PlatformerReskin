using UnityEngine;
using System.Collections;

public class EffectController : MonoBehaviour {
	[Header("Add Scroller Controller here (world)")]
	public ScrollerController scroller;

	[Header("Define and add effect prefabs here")]
	public GameObject dustPoofFX;
	public GameObject bulletHitFX;
	public GameObject coolNewEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnEffect(GameObject _effect, Vector2 location)
	{
		GameObject newFX = Instantiate(_effect, new Vector3(location.x, location.y, 0), Quaternion.identity) as GameObject;
		scroller.mgObjects.Add(newFX);
	}

	public IEnumerator HitPause(float p)
	{
		Time.timeScale = 0.0f;
		float pauseEndTime = Time.realtimeSinceStartup + p;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
		}
		Time.timeScale = 1;
	}
}
