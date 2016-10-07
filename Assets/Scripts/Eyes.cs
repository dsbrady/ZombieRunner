using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour {

	private float defaultFOV;
	private Camera eyes;
	private float zoomFactor = 1.5f;

	// Use this for initialization
	void Start () {
		eyes = GetComponent<Camera>();
		defaultFOV = eyes.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Zoom")) {
			eyes.fieldOfView = defaultFOV / zoomFactor;
		}
		else {
			eyes.ResetFieldOfView();
		}
	}
}
