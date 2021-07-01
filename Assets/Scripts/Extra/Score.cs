using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreTxt;
    public static bool scorePoint = false;
    private int controlScoreUpdate = 0;

    void Update()
    {
        
        //Debug.Log("Score : " + PlayerPrefs.GetInt("Score"));

        if(scorePoint == true)
        {
            scorePoint = false;
            SetScore();
            scoreTxt.text = PlayerPrefs.GetInt("Score").ToString();
        }
        else
        {
            controlScoreUpdate = 0;
        }

        
    }

    private void SetScore()
    {
        if (controlScoreUpdate == 0)
        {
            controlScoreUpdate = 1;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 5);
            //Debug.Log("Score Update : " + PlayerPrefs.GetInt("Score"));
           // Debug.Log(scorePoint);
        }
    }
}
