using UnityEngine;
using System.Collections;

public class ClearCollider : MonoBehaviour {

	private bool canCallHelicopter = true;
	private bool isNewClearArea = false;
	public int currentlyCollidingObjects = 0;
	private float lastTriggerTime;

	// Use this for initialization
	void Start () {
		lastTriggerTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		// We want to not be able to call a helicopter until at least 10 seconds of game time has passed and when the area is clear
		if (Time.realtimeSinceStartup > 10f && isNewClearArea && currentlyCollidingObjects == 0 && (Time.time - lastTriggerTime > 1.0)) {
			isNewClearArea = false;
			canCallHelicopter = true;
			SendMessageUpwards("OnFindClearArea");
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.name != "Player") {
			currentlyCollidingObjects++;
			canCallHelicopter = false;
			isNewClearArea = true;
		}
	}

	void OnTriggerExit(Collider collider) {
		currentlyCollidingObjects--;
		lastTriggerTime = Time.time;
	}

	public bool CanCallHelicopter() {
		return canCallHelicopter;
	}
}
