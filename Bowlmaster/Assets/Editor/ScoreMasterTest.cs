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


}
