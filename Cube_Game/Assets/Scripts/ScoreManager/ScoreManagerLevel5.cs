using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerLevel5 : MonoBehaviour
{
    public static ScoreManagerLevel5 instance;

    public int points, highPoints;
    public float timer, highTimer;
   
    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("HighPointsLevel5"))
        {
            highPoints = PlayerPrefs.GetInt("HighPointsLevel5");
        }
        if (PlayerPrefs.HasKey("HighTimerLevel5"))
        {
            highTimer = PlayerPrefs.GetFloat("HighTimerLevel5");
        }
        else
        {
            highTimer = 100000;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        points = GameObject.Find("Player").GetComponent<PlayerMovement>().scoreValue;
        timer = GameObject.Find("Player").GetComponent<Timer>().t;
    }

    public void UpdateHighTimer()
    {
        highTimer = timer;
        PlayerPrefs.SetFloat("HighTimerLevel5", highTimer);
    }
    public void UpdateHighPoints()
    {
        if (points > highPoints)
        {
            highPoints = points;

            PlayerPrefs.SetInt("HighPointsLevel5", highPoints);
        }
    }
    public void ResetScore()
    {
        points = 0;
    }

    public void ResetStats()
    {
        PlayerPrefs.DeleteKey("HighPointsLevel5");
        highPoints = 0;

        PlayerPrefs.DeleteKey("HighTimerLevel5");
        highTimer = 100000;
    }
}
