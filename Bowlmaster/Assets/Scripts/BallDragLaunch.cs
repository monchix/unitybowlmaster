using UnityEngine;
using System.Collections;

/// <summary>
/// Class: BallDragLaunch
/// Is needed for drag the ball with the mouse or touch and the launch it
///	toma el momento y el lugar donde la bola es agarrada en el canvas y donde se suelta
///	para calcular la velocidad y direcicon de lanzamiento.
/// Requeriment: Ball (object), Start, End
/// </summary>
[RequireComponent (typeof (Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Ball ball; 
	private Vector3 dragStartPos, dragEndPos;
	private float timeStar, timeEnd;



	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		ball = GetComponent<Ball> (); //Get the ball to launch it

	}

	/// <summary>
	/// Capture Time & position of drag star
	/// </summary>
	public void DragStart(){
       
            timeStar = Time.time;
            dragStartPos = Input.mousePosition;
      

	}

	/// <summary>
	/// Moves the start.
	/// </summary>
	/// <param name="xMove">X move.</param>
	public void MoveStart (float xMove){

	
		if (!ball.IsMoving()) {	
			float position = transform.position.x;
			if (position < 52.5f && position > -52.5f)
				ball.transform.Translate (Vector3.right * xMove * Time.deltaTime);
		}

	}

	/// <summary>
	/// Drags the end.
	/// </summary>
	public void DragEnd(){
		// Launch the ball
		if (!ball.IsMoving()) {
			// is true when the ball is moving
			dragEndPos = Input.mousePosition;
			timeEnd = Time.time;
			
			float dragDuration = timeEnd - timeStar;
			float launchSpeedX = (dragEndPos.x - dragStartPos.x) / dragDuration;
			float diffY = (dragEndPos.y - dragStartPos.y); 
			float launchSpeedY =  1.75f*diffY / dragDuration;
		
			Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedY);

			ball.Launch (launchVelocity);
		}
	}
}
