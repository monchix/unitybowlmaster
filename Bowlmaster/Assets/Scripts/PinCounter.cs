using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    /// <summary>
    /// Count the total of pins in the scene
    /// /// </summary>
    /// <param name="lastStandingCount">pins have settle and ball is not in box // new frame</param> 
  
 
    public bool _ballExitBox = false;
    private int _pinFall;
    private int lastStandingCount = 1;
    private int _lastSettleCount = 10;
    private int _currentStanding;
    private float _lastChangeTime; //last time the pins change
    
    private bool _pincounterReady = false;
    private GameManager _gamemanager;


    void Start() {
        _gamemanager = GameManager.FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    void Update()
    {
        // check if ball has enter the box
        if (_ballExitBox)
        {
            UpdateCountPinStanding();
        }

    }

    /// <summary>
    /// Updates the count pin standing.
    /// Count the Pins which are standing and then settle 
    /// </summary>
    private void UpdateCountPinStanding()
    {
        
        float _settleTime;
        _currentStanding = CountStanding();

        // check if the current standing change if change reset the timer
        //Debug.Log(_currentStanding);
        if (_currentStanding != lastStandingCount)
        {
           
            _lastChangeTime = Time.time;
            lastStandingCount = _currentStanding;
            return;
        }

        _settleTime = 3f;  // after 3 seconds pass, let the player play

        if ((Time.time - _lastChangeTime) > _settleTime)
        {
            int pinsFall = _lastSettleCount - _currentStanding;
            _lastSettleCount = _currentStanding;

           
            SetScorePinsHaveSettled(pinsFall);
        }


    }

    private int CountStanding()
    {
        Pin[] _myAllPins;
        int _countPins = 0;
        _myAllPins = FindObjectsOfType<Pin>();
        foreach (Pin myPin in _myAllPins)
        {
            if (myPin)
            {
                if (myPin.IsStanding())
                {
                    _countPins++;
                }

            }
        }


        return _countPins;
    }

    public void Reset() {
        _lastSettleCount = 10;
    }

    public void UpdateStanding() {
        _lastSettleCount = _currentStanding;
    }
    /// <summary>
    /// Sets the score when the pins have settled.
    /// </summary>
    private void SetScorePinsHaveSettled(int pins)
    {
                
        _ballExitBox = false; // the ball is not in the box
        lastStandingCount = -1; //This funtion as a flag to reset the timer reset with every ball
        _pincounterReady = true;
        _pinFall = pins;

        Debug.Log(pins);
        _gamemanager.SetPinsFalls(pins);
       

    }

 


    /// <summary>
    /// When the ball enters in the box of the pinSetter
    /// _ballEnteredBox is true after 4 seconds this change to false
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        GameObject objhit = other.gameObject;

        if (objhit.GetComponent<Ball>())
        {
            //pinText.color = Color.red;
            _ballExitBox = true;

        }
    }
}
