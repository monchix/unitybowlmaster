using UnityEngine;
using System.Collections;

/// <summary>
/// Entity Class: Shredder.
/// </summary>
public class Shredder : MonoBehaviour {

	/// <summary>
	/// Destroies the pins.
	/// </summary>
	/// <param name="pin">Pin.</param>
	void DestroyPins(GameObject pin){
		if (pin.GetComponent<Pin>()) {
			Destroy (pin);
		}
	}

	/// <summary>
	/// The Trigger destroy pins when are out of the shredder
	/// </summary>
	/// <param name="other">Collider of the object</param>
	void OnTriggerExit(Collider other){
		DestroyPins (other.gameObject);
	}
}
