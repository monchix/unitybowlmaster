using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Score master 
/// </summary>
public class ScoreMaster {
    



    // Return a list of cumulative scores, like a normal score card
    public static List <int> ScoreCumulative(List<int> rolls) {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;
                
        foreach (int frameScore in ScoreFrames(rolls)) {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        Debug.Log(cumulativeScores[9]);
        return cumulativeScores;
    }


    // Return a List of individual frame scores, Not cumulative
    public static List<int> ScoreFrames(List<int> rolls) {
        List<int> frameList = new List<int>();
                
        for (int i=1; i< rolls.Count; i+=2) { // index i is the 2nd bowl
            int frameScore = rolls[i - 1] + rolls[i];
            if (rolls[i - 1] == 10)   // Strike Situation
            {                
                if ((rolls.Count - i) >= 2) //Deal with last frame
                {
                    frameScore += rolls[i+1];
                    frameList.Add(frameScore);
                    i--; // Discount 1 so i can deal with the next frame
                } 
                    
            } else if (frameScore == 10) // Spare Situation
                    {
                    if ((rolls.Count - i) >= 2) // I only add when im not in the final frame
                        {
                            frameScore += rolls[i + 1];
                            frameList.Add(frameScore);
                        }
                    }
            else //Normal Situation
            {   //Prevent the 11th frame
                if (frameList.Count<10) { 
                    frameList.Add(frameScore);
                }
            }
        }               
        return frameList;
     }



} 
              

    
   

   



