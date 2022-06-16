using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerLevel2 : MonoBehaviour
{
    public static ScoreManagerLevel2 instance;

    public int points, highPoints;
    public float timer, highTimer;
   

    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("HighPointsLevel2"))
        {
            highPoints = PlayerPrefs.GetInt("HighPointsLevel2");
        }
        if (PlayerPrefs.HasKey("HighTimerLevel2"))
        {
            highTimer = PlayerPrefs.GetFloat("HighTimerLevel2");
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
        PlayerPrefs.SetFloat("HighTimerLevel2", highTimer);
    }
    public void UpdateHighPoints()
    {
        if (points > highPoints)
        {
            highPoints = points;

            PlayerPrefs.SetInt("HighPointsLevel2", highPoints);
        }
    }
    public void ResetScore()
    {
        points = 0;
    }

    public void ResetStats()
    {
        PlayerPrefs.DeleteKey("HighPointsLevel2");
        highPoints = 0;

        PlayerPrefs.DeleteKey("HighTimerLevel2");
        highTimer = 100000;
    }
}
