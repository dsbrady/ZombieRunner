using UnityEngine;
using System.Collections;

public class RadioSystem : MonoBehaviour {

	public AudioClip requestExtraction;
	public AudioClip helicopterInbound;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnFindClearArea() {
		BroadcastMessage("OnCanSummonHelicopter");
	}

	void OnSummonHelicopter() {
		audioSource.clip = requestExtraction;
		audioSource.Play();

		Invoke("DispatchHelicopter", audioSource.clip.length + 1f);
	}

	private void DispatchHelicopter() {
		audioSource.clip = helicopterInbound;
		audioSource.Play();

		BroadcastMessage("OnDispatchHelicopter");
	}
}
