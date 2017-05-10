using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Linq;

public class ScoreMasterTest {
    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }

    //[Test]
    //public void ID01FirstFrameNoStrikeNoBonus()
    //{

    //    int firstBowl = Random.Range(1, 9);
    //    int secondBowl = 9 - firstBowl;

    //    int[] rolls = { firstBowl, secondBowl };
    //    int[] frames = { (firstBowl + secondBowl) };

    //    Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));


    //}

    [Test]
    public void ID02Bowl23() {
        int[] rolls = { 2, 3 };
        int[] frames = { 5 };


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }

    //[Test]
    //public void ID02BowlTwoFramesCompleteNoStrikeorSpare {
    //    int firstBowl = Random.Range(1, 9);
    //    int secondBowl = 9 - firstBowl;
    //    int[] rolls = { firstBowl, secondBowl };
    //    int[] frames = { (firstBowl + secondBowl) };


    //    Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    //}

    [Test]
    public void ID03Bowl234() {
        int[] rolls = { 2, 3, 4 };
        int[] frames = { 5 };


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }

    [Test]
    public void ID04Bowl2345() {
        int[] rolls = { 2, 3, 4, 5 };
        int[] frames = { 5, 9 };


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }

    [Test]
    public void ID05Bowl23456() {
        int[] rolls = { 2, 3, 4, 5, 6 };
        int[] frames = { 5, 9 };


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));


    }

    [Test]
    public void ID06Bowl234561()
    {
        int[] rolls = { 2, 3, 4, 5, 6, 1 };
        int[] frames = { 5, 9, 7 };


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));


    }

    [Test]
    public void ID07Bowl2345612()
    {
        int[] rolls = { 2, 3, 4, 5, 6, 1, 2 };
        int[] frames = { 5, 9, 7 };


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));


    }

    [Test]
    public void ID08BowlX1() {
        int[] rolls = { 10,1 };
        int[] frames = {};


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));


    }

    [Test]
    public void ID09Bowl19() {
        int[] rolls = { 9, 1 };
        int[] frames = {};


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }

    [Test]
    public void ID10Bowl123455() {
        int[] rolls = { 1,2, 3,4, 5,5 };
        int[] frames = {3,7};


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }

    [Test]
    public void ID11SpareBonus()
    {
        int[] rolls = { 1, 2, 3, 5, 5, 5, 3, 3 };
        int[] frames = { 3, 8, 13, 6 };


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }

    [Test]
    public void ID12SpareBonus2()
    {
        int[] rolls = { 1,2, 3,5, 5,5, 3,3, 7,1, 9,1, 6};
        int[] frames = { 3, 8, 13, 6, 8, 16 };


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }


    [Test]
    public void ID13StrikeBonus()
    {
        int[] rolls = { 10, 3, 4};
        int[] frames = { 17, 7};


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }

    [Test]
    public void ID14StrikeBonus2()
    {
        int[] rolls = { 1,2, 3,4, 5,4, 3,2, 10, 1,3, 3,4};
        int[] frames = { 3, 7, 9, 5, 14, 4, 7 };


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }

    [Test]
    public void ID15MultiStrike()
    {
        int[] rolls = { 10, 10, 2 };
        int[] frames = { 22 };


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }

    [Test]
    public void ID16MultiStrike2()
    {
        int[] rolls = { 10, 10, 2,3 };
        int[] frames = { 22, 15, 5 };


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }

    [Test]
    public void ID17MultiStrike3()
    {
        int[] rolls = { 10, 10, 2, 3, 10, 5, 3 };
        int[] frames = { 22, 15, 5, 18, 8 };


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }

    [Test]
    public void ID18TestZerosGame()
    {
        int[] rolls = { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 };
        int[] totalS = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));

    }

    [Test]
    public void ID19TestAllOnes()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1 };
        int[] totalS = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };


        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));

    }

    [Test]
    public void ID20TestAllStrikes()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10,10,10  };
        int[] totalS = { 30, 60, 90, 120, 150, 180, 210, 240, 270, 300 };


        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));

    }

    [Test]
    public void ID21TestImmediateStrikeBonus()
    {
        int[] rolls = { 5,5,3};
        int[] frames = { 13};


        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));

    }

     [Test]
    public void ID22StrikeInLastFrame()
    {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,2,3 };
        int[] totalS = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 33 };



        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));

    }

   

    [Category("Verification")]
    [Test]
    public void TG02GoldenCopyA()
    {
        int[] rolls = { 10, 7,3, 9,0, 10, 0,8, 8,2, 0,6, 10, 10, 10,8,1 };
        int[] totalS = { 20, 39, 48, 66, 74, 84, 90, 120, 148, 167 };



        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));

    }

    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB1of3()
    {
        int[] rolls = { 10, 9, 1, 9, 1, 9, 1, 9, 1, 7, 0, 9, 0, 10, 8, 2, 8, 2, 10 };
        int[] totalS = { 20, 39, 58, 77, 94, 101, 110, 130, 148, 168 };



        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));

    }

    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB2of3()
    {
        int[] rolls = { 10, 10, 10, 10, 9,0 , 10, 10, 10, 10, 10, 9, 1};
        int[] totalS = { 30, 60, 89, 108, 117, 147, 177, 207, 236, 256 };



        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));

    }







}
