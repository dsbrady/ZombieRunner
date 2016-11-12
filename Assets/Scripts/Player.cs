using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/* TODO:
1) Create opening menu scene
2) Instructions screen
*/

public class Player : MonoBehaviour {

	public GameObject landingAreaPrefab;

	private bool canSummonHelicopter = false;
	private GameObject landingArea;
	private bool respawnTrigger = false;
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

		if (canSummonHelicopter && Input.GetButtonUp("CallHelicopter")) {
			SummonHelicopter();
		}
	}

	private void Respawn() {
		// The first "spawnPoint" is actually the parent container, so start at 1
		int spawnPointNumber = Random.Range(1,spawnPoints.Count);

		gameObject.transform.position = spawnPoints[spawnPointNumber].position;
		gameObject.transform.rotation = spawnPoints[spawnPointNumber].rotation;
	}

	void OnFindClearArea() {
		canSummonHelicopter = true;
	}

	private void CreateLandingArea() {
		if (landingArea) {
			Destroy(landingArea);
		}
		Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		landingArea = Instantiate(landingAreaPrefab, position, Quaternion.identity) as GameObject;

	}

	private void SummonHelicopter() {
		// Send a radio message to the helicopter, then a second or so later, have the helicopter pilot respond

		// Drop a flare and create the landing are
		CreateLandingArea();

		SendMessageUpwards("OnSummonHelicopter");
	}
}
