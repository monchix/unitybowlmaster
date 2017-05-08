using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Action Master Class
/// </summary>
public class ActionMaster
{
    public enum Action { Tidy, Reset, EndTurn, EndGame };
    private static int bowl = 1;
    private static int[] bowls = new int[21];
        

    public static Action NextAction(List<int> pinFalls) {

        bowl = 1;
        ActionMaster am = new ActionMaster();
        Action currentAction = new Action();
      

        foreach (int pins in pinFalls){
            currentAction = am.Bowl(pins);
        }

        return currentAction;
        

    }



  
    /// <summary>
    /// Spare ---> Reset 
    /// </summary>
    /// <returns></returns>
    private  bool AllPinsAreKnockedDown() {

        return ((bowls[19 - 1] + bowls[20 - 1]) % 10) == 0;

    }

    /// <summary>
    /// Spare ---> Reset 
    /// </summary>
    /// <returns></returns>
    private  bool StrikesorSpareLastFrame()
    {

        return ((bowls[19 - 1] + bowls[20 - 1]) % 10 == 0);

    }

    /// <summary>
    /// Strike in 20 --> Tidy
    /// </summary>
    /// <returns></returns>

    private  bool IsBall21Reward(){
        return (bowls[19 - 1] + bowls[20 - 1]) >= 10;
    }


    private Action Bowl(int pins)
    {

        Debug.Log("pins hit " + pins);
        if (pins < 0 || pins > 10) { throw new UnityException("Error pins must be between 0 to 10"); }

        bowls[bowl-1] = pins; //save the number of pins
       
        //Last Ball
        if (bowl == 21) /// Final Frame 3 ball 
        {            
            return Action.EndGame;
        }

        //Last Frame
        if (bowl == 19 && pins==10) //Strike in last frame
        {
            bowl ++;
           
            return Action.Reset;
        }
        else if (bowl == 20) //Spare last frame
        {
            bowl++;
            if ((bowls[19 - 1]==10) && (bowls[20 - 1]!=10))
            {
              
                return Action.Tidy;
            }
            else if (StrikesorSpareLastFrame()){
             
                return Action.Reset;
            }
            else if (IsBall21Reward())
            {
                
                return Action.Tidy;
            }
            else {

              
                return Action.EndGame;
            }
        }

        ///Frame 1-9 

        
        if (bowl % 2 != 0) /// 1st ball
        {
            
            if (pins == 10)  ///Strike 
            {

                Debug.Log("bowl: " + bowl);
                bowl += 2;
                return Action.EndTurn;
            }
            else
            {

                Debug.Log("bowl: " + bowl);
                bowl += 1; ///inc the bowl so the next time is end frame  
                
                return Action.Tidy;
            }
        }
        else if (bowl % 2 == 0) // 2nd ball
        {
            Debug.Log("bowl: " + bowl);
            bowl += 1;
            return Action.EndTurn;
        }

      
        ///Other Behaviour here
        throw new UnityException("Not sure what action do now");
    }

    

}
