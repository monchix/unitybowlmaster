using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {

    private List<int> pinFalls;
    private ActionMaster.Action _currentAction;
    private PinSetter _pins;
    private PinCounter _pincounter;
    private Ball _ball;
    private ScoreDisplay _scoredisplay;
    

    // Use this for initialization
    void Start () {
        _ball = GameObject.FindObjectOfType<Ball>();
        _pincounter = GameObject.FindObjectOfType<PinCounter>();
        _scoredisplay = GameObject.FindObjectOfType<ScoreDisplay>();
        _pins = GameObject.FindObjectOfType<PinSetter>();
        pinFalls = new List<int>();

	}
	
	// Update is called once per frame
	void Update () {
       
    }
             
    public void SetPinsFalls(int pins) {

         pinFalls.Add(pins);
        _ball.Reset();
        _scoredisplay.SetScore(pins);
        _currentAction = ActionMaster.NextAction(pinFalls);
        _pins.PerformAction(_currentAction);
        
        
    }
       

}
