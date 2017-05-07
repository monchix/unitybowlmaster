using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Class for Test Driven Development
/// </summary>
[TestFixture]
public class ActionMasterTest{

    private List<int> pinFalls;
	private ActionMaster.Action endTurn=ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;




    [SetUp]
    public void Setup() {
        pinFalls = new List<int>();
    }


    /// <summary>
    /// If there is an strike will be an End Turn
    /// </summary>
    [Test]
    public void T01StrikeReturnsEndTurn(){
        

        pinFalls.Add(10);

        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
        
    }

   // /// <summary>
   // /// No strike so return a Tidy action
   // /// </summary>
    [Test]
    public void T02Bowl1to9ReturnsTidy() {
        

        var randomInt = Random.Range(1, 9);

        pinFalls.Add(randomInt);

        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
       

    }

   // /// <summary>
   // /// Two Throws return an end turn action
   // /// </summary>
    [Test]
    public void T03Bowl2ThrowsReturnsEndTurn() {
        

        var randomInt = Random.Range(1, 9);
        var diffpin = 9 - randomInt;

        int[] rolls = { randomInt, diffpin };

        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
   }
    
   [Test]
   public void T04Ball21ReturnsEndGame() {
       int[] pinsdown = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,8 };
       
        Assert.AreEqual(endGame, ActionMaster.NextAction(pinsdown.ToList()));
    }

    [Test]
    public void T04Ball20NoRewardReturnsEndGame()
    {
        int[] pinsdown = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};

               
        Assert.AreEqual(endGame, ActionMaster.NextAction(pinsdown.ToList()));
   }

   // /// <summary>
   // ///  Return a reset in the last frame if there is an strike in the 19 throw
   // /// </summary>
    [Test]
    public void T05Ball20StrikeReturnTidy() {
       int[] pinsdown = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 4,10};
       
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinsdown.ToList())); 
    }

    [Test]
    public void T06Strike19Ball20NotStrikeTidy()
    {
        int[] pinsdown = {1,1,1,1,1,1,1,1,1,1,1,1,1,4,3,2,4,6,10,5};
       
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinsdown.ToList()));
    }

    [Test]
    public void T07Strike19NoPinsin20Reward21Tidy()
    {
        int[] pinsdown = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 3, 2, 4, 6, 10,0 };
       
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinsdown.ToList()));
    }


    [Test]
    public void T07Strike2BallReturnEndTurn()
    {
        int[] pinsdown = {0,10,5,1};
       

        
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinsdown.ToList()));
    }

    [Test]
    public void T08Dondi10thFrameTurkey()
    {
        int[] pinsdown = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,10,10,10 };
     
      
        Assert.AreEqual(endGame, ActionMaster.NextAction(pinsdown.ToList()));

    }

    [Test]
    public void T08ZeroHitFirstBallthenAnyReturnEndTurn()
    {

        int[] pinsdown = {0,8};

        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinsdown.ToList()));
    }


    /// <summary>
    ///  Return a reset in the last frame if there is an spare in the 2 last rounds
    /// </summary>
     [Test]
      public void T05CheckResetAtSpareinLastFrame()
      {
          int[] pinsdown = {10,10,10,10,10,10,10,10,10,4,6};
        
         Assert.AreEqual(reset, ActionMaster.NextAction(pinsdown.ToList()));
    }

}
