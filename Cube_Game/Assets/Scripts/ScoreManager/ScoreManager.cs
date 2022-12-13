using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int points, highPoints;
    public float timer, highTimer;
    

    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("HighPointsLevel1"))
        {
            highPoints = PlayerPrefs.GetInt("HighPointsLevel1");
        }
        if (PlayerPrefs.HasKey("HighTimerLevel1"))
        {
            highTimer = PlayerPrefs.GetFloat("HighTimerLevel1");
        }
        else
        {
            highTimer = 100000;
        }
    }
 
    void Update()
    {
        points = GameObject.Find("Player").GetComponent<PlayerMovement>().scoreValue;
        timer = GameObject.Find("Player").GetComponent<Timer>().t;
       
    }

    public void UpdateHighTimer()
    {    
            highTimer = timer;
            PlayerPrefs.SetFloat("HighTimerLevel1", highTimer);  
    }
   public void UpdateHighPoints()
    {
        if(points > highPoints)
        {
            highPoints = points;

            PlayerPrefs.SetInt("HighPointsLevel1", highPoints);
        }
    }
    public void ResetScore()
    {
        points = 0;
    }

    public void ResetStats()
    {
        PlayerPrefs.DeleteKey("HighPointsLevel1");
        highPoints = 0;

        PlayerPrefs.DeleteKey("HighTimerLevel1");
        highTimer = 100000;
    }
}
