using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Entity Class: PinSetter
/// </summary>
public class PinSetter : MonoBehaviour
{
    /// <summary>
    /// Put a group of pins in the scene 
    /// /// </summary>
   
    public GameObject pinSet;
    private ActionMaster _actionMaster = new ActionMaster();
    private Animator _animPinSetter;
    //private ActionMaster.Action currentAction = new ActionMaster.Action();

    private List<int> pinFalls;
    private PinCounter _pincounter;
   

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {
        
        _animPinSetter = GetComponent<Animator>();
        _pincounter = GameObject.FindObjectOfType<PinCounter>();
        pinFalls = new List<int>();
       

    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    void Update()
    {
        

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

        // _currentStanding = 10;
       
        GameObject newPins = Instantiate(pinSet, new Vector3(0, 30, 1829), Quaternion.identity) as GameObject;
    }

    
    public void PerformAction(ActionMaster.Action act)
    {
        if (act == ActionMaster.Action.Tidy)
        {
            this.TidyAnimation();
        }
        else if (act == ActionMaster.Action.Reset)
        {
            this.ResetAnimation();
        }
        else if (act == ActionMaster.Action.EndGame)
        {

            this.EndGameAnimation();
        }
        else if (act == ActionMaster.Action.EndTurn)
        {

            this.EndTurnAnimation();
        }
    }
    
    public void ResetAnimation()
   {
        Debug.Log("Reset");
        _pincounter.Reset();
        _animPinSetter.SetTrigger("resetTrigger");
        
    }

    public void TidyAnimation()
    {

        _pincounter.UpdateStanding();
        //Debug.Log("pins stand= "+ _lastSettleCount);
        Debug.Log("Tidy");
        _animPinSetter.SetTrigger("tidyTrigger");
    }

    public void EndTurnAnimation()
    {
        Debug.Log("EndTurn");
        _pincounter.Reset();
        _animPinSetter.SetTrigger("resetTrigger");
        
    }

    public void EndGameAnimation()
   {
        Debug.Log("EndGame");
        _pincounter.Reset();
        _animPinSetter.SetTrigger("resetTrigger");
        
    }
}
