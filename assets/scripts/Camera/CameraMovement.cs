using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private float horizontalSpeed = 2.0F;
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		float h = horizontalSpeed * Input.GetAxis("Mouse X");
		transform.Rotate(0, h, 0,Space.World);
	}
}
