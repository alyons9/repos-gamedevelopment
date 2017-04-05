using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	GameObject mainCamera;
	GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate(){
		// follow player with camera
		transform.position = player.transform.position;
	}
}
