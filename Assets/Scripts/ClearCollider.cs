using UnityEngine;
using System.Collections;

public class ClearCollider : MonoBehaviour {

	//TODO: make this private
	public int currentlyCollidingObjects = 0;
	private bool isHelicopterIdle = true;
	private bool isNewClearArea = false;
	private float lastTriggerTime;

	// Use this for initialization
	void Start () {
		lastTriggerTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		// We want to not be able to call a helicopter until at least 10 seconds of game time has passed and when the area is clear
		if (isHelicopterIdle && Time.realtimeSinceStartup > 10f && isNewClearArea && currentlyCollidingObjects == 0 && (Time.time - lastTriggerTime > 1.0)) {
			isNewClearArea = false;
			SendMessageUpwards("OnFindClearArea");
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.name != "Player") {
			currentlyCollidingObjects++;
		}
	}

	void OnTriggerExit(Collider collider) {
		currentlyCollidingObjects--;
		lastTriggerTime = Time.time;
		isNewClearArea = true;
	}

	void OnDispatchHelicopter() {
		isHelicopterIdle = false;
	}
}
