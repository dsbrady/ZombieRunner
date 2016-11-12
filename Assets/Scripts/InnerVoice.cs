using UnityEngine;
using System.Collections;

public class InnerVoice : MonoBehaviour {

	public AudioClip chopperCanLandHere;
	public AudioClip whereAmI;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = whereAmI;
		audioSource.Play();
	}
	
	void OnCanSummonHelicopter () {
		audioSource.clip = chopperCanLandHere;
		audioSource.Play();
	}
}
