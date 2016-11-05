using UnityEngine;
using System.Collections;

public class ClearCollider : MonoBehaviour {

	public AudioClip chopperCanLandClip;

	private AudioSource audioSource;
	private bool canPlayClip = true;
	private bool isColliding = false;
	private float lastTriggerTime;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		lastTriggerTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (!isColliding && canPlayClip && (Time.time - lastTriggerTime > 1.0)) {
			// Set isColliding to true to make sure this only happens once per clear space
			isColliding = true;
			canPlayClip = false;
			audioSource.clip = chopperCanLandClip;
			audioSource.Play();
		}
	}

	void OnTriggerEnter(Collider collider) {
		canPlayClip = false;
		isColliding = true;
	}

	void OnTriggerExit(Collider collider) {
		canPlayClip = true;
		isColliding = false;
		lastTriggerTime = Time.time;
	}

	public bool CanCallHelicopter() {
		return !isColliding;
	}
}
