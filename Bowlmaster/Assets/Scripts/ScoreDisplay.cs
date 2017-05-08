using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    public Text pinText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScore(int score)
    {
        pinText.text = score.ToString();
        pinText.color = Color.green;
    }

    public void ChangeColor() {

        pinText.color = Color.red;
    }

}
