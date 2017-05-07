using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Entity Class: PinSetter
/// </summary>
public class PinSetter : MonoBehaviour
{
    /// <summary>
    /// Put a group of pins in the scene 
    /// /// </summary>
    /// <param name="lastStandingCount">pins have settle and ball is not in box // new frame</param> 
    /// <param name="pinText">Score</param>
    /// <param name="pinSet">Group of game objects of the pinset</param>

    public Text pinText;
    public GameObject pinSet;
    public bool _ballExitBox = false;

    private int lastStandingCount = 1;
    private int _lastSettleCount = 10;
    private int _currentStanding;
    private float _lastChangeTime; //last time the pins change
    private Ball _ball;
    private ActionMaster _actionMaster = new ActionMaster();
    private Animator _animPinSetter;
    private ScoreMaster score;
    

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {
        _ball = GameObject.FindObjectOfType<Ball>();
        _animPinSetter = GetComponent<Animator>();
      
      
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
    /// Raises the pins.
    /// </summary>
    public void RaisePins()
    {
        Pin[] _myAllPins;
        _myAllPins = FindObjectsOfType<Pin>();
        foreach (Pin myPin in _myAllPins)
        {
            myPin.Raise();
        }
    }


    /// <summary>
    /// Lowers the pins.
    /// </summary>
    public void LowerPins()
    {
        Pin[] _myAllPins;
        _myAllPins = FindObjectsOfType<Pin>();
        foreach (Pin myPin in _myAllPins)
        {
            myPin.Lower();
            
        }

        
       

    }

    /// <summary>
    /// Renews the pins.
    /// </summary>
    public void RenewPins()
    {

        ///Is necesary a relative distance between the collider for that we use
        ///20 in the y, otherwise the pins go through of the floor
        /// The problem here was that we defined a global position instead 
        /// of relative position inside the Collider for that reason
        /// when we put 0 - 25 the pins go down the floor and outside the 
        /// collider, we need to change to Space Local
        ///Dev-Video: 026 Time: 18:00; 

        //Vector3 pos = new Vector3(0, 0, 1829);

        _currentStanding = 10;
        pinText.color = Color.black;
        pinText.text = _currentStanding.ToString();
        GameObject newPins = Instantiate(pinSet, new Vector3(0, 30, 1829), Quaternion.identity) as GameObject;
    }


    /// <summary>
    /// Updates the count pin standing.
    /// Count the Pins which are standing and then settle 
    /// </summary>
    void UpdateCountPinStanding()
    {
        float _settleTime;
       _currentStanding = CountStanding();
         
        // check if the current standing change if change reset the timer
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


    /// <summary>
    /// Sets the score when the pins have settled.
    /// </summary>
    public void SetScorePinsHaveSettled(int pins)
    {
      

        pinText.color = Color.green;
       
        _ball.Reset();
        _ballExitBox = false; // the ball is not in the box
        lastStandingCount = -1; //This funtion as a flag to reset the timer reset with every ball

        pinText.text = pins.ToString();
        ActionMaster.Action action = _actionMaster.Bowl(pins);
        ActionAnimation(action);

    }

    private void ActionAnimation(ActionMaster.Action act)
    {
        if (act == ActionMaster.Action.Tidy)
        {
            this.Tidy();
        }
        else if (act == ActionMaster.Action.Reset)
        {
            this.Reset();
        }
        else if (act == ActionMaster.Action.EndGame)
        {

            this.EndGame();
        }
        else if (act == ActionMaster.Action.EndTurn)
        {

            this.EndTurn();
        }
    }

    public int CountStanding()
    {
        Pin[] _myAllPins;
        int _countPins = 0;
        _myAllPins = FindObjectsOfType<Pin>();
        foreach (Pin myPin in _myAllPins)
        {
            if (myPin)
            {
                if (myPin.isStanding())
                {
                    _countPins++;
                }

            }
        }


        return _countPins;
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
            pinText.color = Color.red;
            _ballExitBox = true;

        }
    }

    public void Reset()
   {
        Debug.Log("Reset");
        _lastSettleCount = 10;
        _animPinSetter.SetTrigger("resetTrigger");
        
    }

    public void Tidy()
    {
        _lastSettleCount = _currentStanding;
        Debug.Log("pins stand= "+ _lastSettleCount);
        Debug.Log("Tidy");
        _animPinSetter.SetTrigger("tidyTrigger");
    }

    public void EndTurn()
    {
        Debug.Log("EndTurn");
        _lastSettleCount = 10;
        _animPinSetter.SetTrigger("resetTrigger");
        
    }

    public void EndGame()
   {
        Debug.Log("EndGame");
        _lastSettleCount = 10;
        _animPinSetter.SetTrigger("resetTrigger");
        
    }
}
