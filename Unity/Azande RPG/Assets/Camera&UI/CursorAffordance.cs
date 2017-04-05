using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour {

	[SerializeField] Texture2D walkCursor = null;
	[SerializeField] Texture2D attackCursor = null;
	[SerializeField] Texture2D errorCursor = null;
	[SerializeField] Vector2 currentHotspot = new Vector2(0,0);

	CameraRaycaster cameraRaycaster;

	// Use this for initialization
	void Start () {
		cameraRaycaster = GetComponent<CameraRaycaster> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
//		Cursor.SetCursor (walkCursor, currentHotspot, CursorMode.Auto);
		switch (cameraRaycaster.layerHit) {
		case Layer.Walkable:
			Cursor.SetCursor (walkCursor, currentHotspot, CursorMode.ForceSoftware);
			break;
		case Layer.Enemy:
			Cursor.SetCursor (attackCursor, currentHotspot, CursorMode.ForceSoftware);
			break;
		case Layer.RaycastEndStop:
			Cursor.SetCursor (errorCursor, currentHotspot, CursorMode.ForceSoftware);
			break;
		default:
			Debug.LogError ("Dont know what the cursor is on");
			break;
		}
	}
}
