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
        List<int> rollsbyFrame = new List<int>();
       
        int rollslenght = 0;
              
        //I considerer only pair sets of bowls
        if (rolls.Count % 2 == 0) rollslenght = rolls.Count;
        else rollslenght = rolls.Count-1;
        

        for (int i=0; i< rollslenght; i=i+2) {
            // List to save the score of each middle frame
            rollsbyFrame = rolls.GetRange(i,2);
            //Reset the score of each frame
            int score = 0;
            //PRocess to deal with spares or strikes
            int spareScore = rollsbyFrame[0] + rollsbyFrame[1];
                     
            if (rollsbyFrame[0] == 10)
            {
                //count the rolls left in the score, with this i can 
                // check the   acumulative scores strkes
                int rollsleft = rolls.Count - (i+1);
                //if is impair i have {10,3,2}= 15 or {5,2, 10, 2,3}={7,15,5}
                if ((rollsleft) >= 2) 
                {
                    score = CalculateScore(rolls, i);
                    frameList.Add(score);
                    // Discount 1 because is the 1st frame and if i add 2 will lost one score  {10, 1, 2} = 13 score    
                    i--;
                } 
                    
            } else if (spareScore == 10)
                    {
                    //Deal with spares in the middle
                    //otherwise i will not record the score
                    // Here i check the total rolls.
                        if (i + 2 != rolls.Count)
                        {
                            score = CalculateScore(rolls, i);
                            frameList.Add(score);
                            }

                        }
            else
                { if (frameList.Count<10) { 
                    foreach (int roll in rollsbyFrame)
                            {score += roll;}
                                              
                        frameList.Add(score);
                    }
                }
        }
                     
        return frameList;


     }

    private static int CalculateScore(List<int> rolls, int i) {
        int score = 0;
        List <int> xframes = rolls.GetRange(i, 3);
        foreach (int roll in xframes)
        {
            score += roll;
        }
       return score;
    }

} 
              

    
   

   



