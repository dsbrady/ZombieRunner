using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	public AudioClip summonClip;

	private AudioSource audioSource;
	private bool isIdle = true;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isIdle && Input.GetButtonUp("CallHelicopter")) {
			Summon();
		}
	}

	public void Summon() {
		this.isIdle = false;

		audioSource.clip = summonClip;
		audioSource.Play();
		Debug.Log("calling helicopter");
	}
}
