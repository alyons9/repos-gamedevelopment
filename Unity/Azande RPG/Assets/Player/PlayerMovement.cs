using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{

	bool isInDirectMode = false;
	[SerializeField] float walkMoveStopRadius = 0.2f;
    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
        
    private void Start()
    {
		cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
		if (Input.GetKeyDown (KeyCode.G))
			isInDirectMode = !isInDirectMode;

		if (isInDirectMode) {
			processDirectMovement ();
		} else {
			processMouseMovement ();
		}
    }

	private void processDirectMovement () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 m_CamForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
		Vector3 m_Move = v*m_CamForward + h*Camera.main.transform.right;

		m_Character.Move (m_Move, false, false);
	}

	private void processMouseMovement(){
		if (Input.GetMouseButton(0))
		{
			print ("Cursor hit layer: " + cameraRaycaster.layerHit);
			print("Cursor raycast hit" + cameraRaycaster.hit.collider.gameObject.name.ToString());

			switch (cameraRaycaster.layerHit) {
			case Layer.Walkable:
				currentClickTarget = cameraRaycaster.hit.point;
				break;
			case Layer.Enemy:
				print ("Not moving to enemy");
				break;
			default:
				print ("SHOULDNT BE HERE!!!");
				break;
			}

		}

		var playerToClickPoint = currentClickTarget - transform.position;
		if (playerToClickPoint.magnitude >= walkMoveStopRadius) {
			m_Character.Move (playerToClickPoint, false, false);
		} else {
			m_Character.Move (Vector3.zero, false, false);
		}

	}
}

