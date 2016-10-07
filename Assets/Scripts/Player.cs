using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public bool respawnTrigger = false;

	private Transform spawnPointContainer;
	private List<Transform> spawnPoints = new List<Transform>();

	// Use this for initialization
	void Start () {
		spawnPointContainer = GameObject.Find("Player Spawn Points").transform;
		spawnPointContainer.GetComponentsInChildren<Transform>(false, spawnPoints);
	}
	
	// Update is called once per frame
	void Update () {
		if (respawnTrigger) {
			respawnTrigger = false;
			Respawn();
		}
	}

	private void Respawn() {
		// The first "spawnPoint" is actually the parent container, so start at 1
		int spawnPointNumber = Random.Range(1,spawnPoints.Count);

		gameObject.transform.position = spawnPoints[spawnPointNumber].position;
		gameObject.transform.rotation = spawnPoints[spawnPointNumber].rotation;
	}
}
