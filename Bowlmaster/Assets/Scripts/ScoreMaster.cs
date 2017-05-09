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

        return cumulativeScores;
    }


    // Return a List of individual frame scores, Not cumulative
    public static List<int> ScoreFrames(List<int> rolls) {
        List<int> frameList = new List<int>();
        List<int> rollsbyFrame = new List<int>();
        List<int> xframes = new List<int>();
        int score=0;
        int rollslenght = 0;

       

        if (rolls.Count % 2 == 0)
        {
            rollslenght = rolls.Count;
        }
        else {
            rollslenght = rolls.Count-1;
        }

        

        for (int i=0; i< rollslenght; i=i+2) {
            // List to save the score of each middle frame
            rollsbyFrame = rolls.GetRange(i,2);

            //Reset the score of each frame
            score = 0;

            //PRocess to deal with spares or strikes
            int spareScore = rollsbyFrame[0] + rollsbyFrame[1];
            if (rollsbyFrame[0] == 10)
            {
                foreach (int roll in rollsbyFrame)
                {
                    score += roll;
                }
                //frameList.Add(score);
            }else if (spareScore == 10)
                  {
                //Deal with spares in the middle
                //otherwise i will not record the score
                    Debug.Log(i + "uno " +rollslenght);
                    // Here i check the total rolls.
                        if (i + 2!= rolls.Count) {
                            Debug.Log(i + "dos " +rollslenght);
                        
                            xframes = rolls.GetRange(i, 3);
                            foreach (int roll in xframes)
                            {
                                score += roll;
                            }
                            Debug.Log(score);
                            frameList.Add(score);
                         }
                 
                    }
                   else
                    { 
                        foreach (int roll in rollsbyFrame)
                        {                
                                score += roll;
            
                        }
                            Debug.Log(score);
                            frameList.Add(score);
                    }
        }
        return frameList;
    }




}
