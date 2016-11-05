using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	public AudioClip summonClip;

	private AudioSource audioSource;
	private ClearCollider clearCollider;
	private bool isIdle = true;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		clearCollider = GameObject.FindObjectOfType<ClearCollider>();
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(clearCollider.CanCallHelicopter());
		if (this.isIdle && clearCollider.CanCallHelicopter() && Input.GetButtonUp("CallHelicopter")) {
			Summon();
		}
	}

	public void Summon() {
		this.isIdle = false;

		audioSource.clip = summonClip;
		audioSource.Play();

		rigidBody.velocity = new Vector3(0,0,50f);
	}
}
