using UnityEngine;
using System.Collections;

/// <summary>
/// Entity Class: Ball
/// </summary>
public class Ball : MonoBehaviour {

	// Use this for initialization
	public Vector3 launchVelocity;
	public float boundaryX;
	public float boundaryY;
	public bool inPlay;

	private AudioSource _ballSound;
	private Rigidbody _rb;
	private Vector3 _startPosition;
    private bool _ballMoving = false;

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start () {
		_rb = GetComponent<Rigidbody> ();
		_rb.useGravity = false; //at start the ball has no gravity
		_startPosition = transform.position;

	}

	/// <summary>
	/// Reset this instance
	/// </summary>
	public void Reset(){

		
		_rb.useGravity = false;
		transform.position = _startPosition;
		_rb.velocity = new Vector3 (0,0,0);
		_rb.angularVelocity = new Vector3 (0,0,0);
        _rb.transform.rotation = Quaternion.identity;
		_ballMoving = false;
		inPlay=false;

	}

	/// <summary>
	/// Launch the specified velocity.
	/// </summary>
	/// <param name="velocity">Velocity.</param>
	public void Launch (Vector3 velocity)
	{
			inPlay = true;
			_rb.useGravity = true; //activate the gravity
			_rb.velocity = velocity; //take the velocity of the user 
			_ballSound = GetComponent<AudioSource> ();
			_ballSound.Play ();
			_ballMoving = true;

	}

    public bool IsMoving() {
        if (this._ballMoving)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
