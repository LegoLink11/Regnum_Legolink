using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private Vector3 CameraMovement;
	public float cameraSpeed;
	public float zoomSpeed;
	public float minZoom;
	public float maxZoom;

	void Start ()
	{


	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float zoom = Input.GetAxis("Mouse ScrollWheel");

		if(zoom != 0f)
		{
			Camera.main.orthographicSize -= zoom * zoomSpeed;
			Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
		}
		CameraMovement.Set(moveHorizontal, moveVertical, 0f);
		transform.Translate(CameraMovement * cameraSpeed);
	}
}
