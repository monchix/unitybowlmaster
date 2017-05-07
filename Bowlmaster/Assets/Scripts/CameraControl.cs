using UnityEngine;
using System.Collections;

/// <summary>
/// Entity Class: Camera control.
/// </summary>
public class CameraControl : MonoBehaviour {

	public Ball ball;


	private Vector3 _offset;
	// Use this for initialization

	/// <summary>
	/// Start this instance, calculate the offset for the camera
	/// </summary>
	void Start () {
		_offset = transform.position - ball.transform.position;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		// this limit the x position in the field
		if (ball.transform.position.z <= 1829f)  {
			//The camera position is move with the ball
			transform.position = ball.transform.position + _offset;
		}
	}
}
