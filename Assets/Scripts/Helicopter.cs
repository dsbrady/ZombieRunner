using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	private bool isIdle = true;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}
	
	void OnDispatchHelicopter() {
		this.isIdle = false;

		rigidBody.velocity = new Vector3(0,0,50f);
	}
}
