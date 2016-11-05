using UnityEngine;
using System.Collections;

public class DayCycle : MonoBehaviour {

	public float minutesPerSecond = 60;

	private int minutesPerDay = 1440;
	private Quaternion startRotation;

	// Use this for initialization
	void Start () {
		startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		float thisFrameAngle = minutesPerSecond * Time.deltaTime / 360;
		transform.RotateAround(transform.position, Vector3.forward, thisFrameAngle);
	}
}
