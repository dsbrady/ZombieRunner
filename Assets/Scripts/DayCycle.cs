using UnityEngine;
using System.Collections;

public class DayCycle : MonoBehaviour {

	public float minutesPerSecond = 60;

	// Update is called once per frame
	void Update () {
		float thisFrameAngle = minutesPerSecond * Time.deltaTime / 360;
		transform.RotateAround(transform.position, Vector3.forward, thisFrameAngle);
	}
}
