using UnityEngine;
using System.Collections;


/// <summary>
/// Enitity Class: Pin.
/// </summary>
public class Pin : MonoBehaviour {
	public float standingThershold= 4f; 
	public float distToRaise= 50f;

	private Rigidbody _rbPin;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		_rbPin = GetComponent<Rigidbody> ();
	}

	public bool isStanding (){
		float standX = Mathf.Abs(270-transform.rotation.eulerAngles.x); //Detect the angle of the item.
		float standY = Mathf.Abs(transform.rotation.eulerAngles.y);
		if (standX < standingThershold || standY < standingThershold || standX > 360-standingThershold || standY > 360-standingThershold)
			return true;
		else return false;

	}

	/// <summary>
	/// Raise this instance.
	/// raise standings pins only by distanceToRaise
	/// </summary>
	public void Raise(){
		

				if (isStanding ()) {
					_rbPin.useGravity= false;
					//_rbPin.freezeRotation= true;
                     _rbPin.transform.rotation = Quaternion.Euler(-90f, 0, 0);
                     
                    // Dev-Video: 025 Time: 17:20; 
                    // Space.World is the global position, otherwise is relative position
                    transform.Translate (Vector3.up*distToRaise, Space.World);
				}
			}
		

	
 	/// <summary>
	/// Lower  pins only by distanceToRaise
 	/// </summary>
	public void Lower(){
        //_rbPin.freezeRotation = true;
        //_rbPin.useGravity = false;
        
        _rbPin.transform.rotation = Quaternion.Euler(-90, 0, 0);
        _rbPin.isKinematic = true;
        transform.Translate (Vector3.down * distToRaise, Space.World);
        _rbPin.isKinematic = false;
        //_rbPin.useGravity = true;
        //_rbPin.freezeRotation = false;

    }

    /// <summary>
    /// Otherwise the pins move like a crazy after the fall
    /// </summary>
    public void ActivatePin() {
        _rbPin.useGravity = true;
        _rbPin.freezeRotation = false;
    }


}
