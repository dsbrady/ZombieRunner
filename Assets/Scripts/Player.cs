using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/* TODO:
1) Create opening menu scene
2) Instructions screen
*/

public class Player : MonoBehaviour {

	public Helicopter helicopter;

	/* TODO: Record audio clips */
	public AudioClip whatHappened;
	public AudioClip foundClearArea;

	private AudioSource innerVoice;
	private bool respawnTrigger = false;
	private Transform spawnPointContainer;
	private List<Transform> spawnPoints = new List<Transform>();

	// Use this for initialization
	void Start () {
		spawnPointContainer = GameObject.Find("Player Spawn Points").transform;
		spawnPointContainer.GetComponentsInChildren<Transform>(false, spawnPoints);

		AudioSource[] audioSources = GetComponents<AudioSource>();
		foreach (AudioSource audiosource in audioSources) {
			if (audiosource.priority == 1) {
				innerVoice = audiosource;
				break;
			}
		}

		innerVoice.clip = whatHappened;
		innerVoice.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (respawnTrigger) {
			respawnTrigger = false;
			Respawn();
		}
	}

	void OnFindClearArea() {
		innerVoice.clip = foundClearArea;
		innerVoice.Play();
		Debug.Log("Found clear area in player");
	}

	private void Respawn() {
		// The first "spawnPoint" is actually the parent container, so start at 1
		int spawnPointNumber = Random.Range(1,spawnPoints.Count);

		gameObject.transform.position = spawnPoints[spawnPointNumber].position;
		gameObject.transform.rotation = spawnPoints[spawnPointNumber].rotation;
	}
}
