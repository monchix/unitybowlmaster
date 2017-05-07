using UnityEngine;
using System.Collections;

/// <summary>
/// Ball shredder.
/// </summary>
public class BallShredder : MonoBehaviour {

	private Ball ball;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}

	/// <summary>
	/// Raises the trigger exit event.
	/// </summary>
	/// <param name="other">Collider</param>
	void OnTriggerExit(Collider other){
		if (other.gameObject.GetComponent<Ball>()) {
			ball.Reset ();

		}
	}
}
