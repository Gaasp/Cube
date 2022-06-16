using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerLevel3 : MonoBehaviour
{
    public static ScoreManagerLevel3 instance;

    public int points, highPoints;
    public float timer;
    public float highTimer;
    

    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("HighPointsLevel3"))
        {
            highPoints = PlayerPrefs.GetInt("HighPointsLevel3");
        }
        if (PlayerPrefs.HasKey("HighTimerLevel3"))
        {
            highTimer = PlayerPrefs.GetFloat("HighTimerLevel3");
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
        PlayerPrefs.SetFloat("HighTimerLevel3", highTimer);
    }
    public void UpdateHighPoints()
    {
        if (points > highPoints)
        {
            highPoints = points;

            PlayerPrefs.SetInt("HighPointsLevel3", highPoints);
        }
    }
    public void ResetScore()
    {
        points = 0;
    }

    public void ResetStats()
    {
        PlayerPrefs.DeleteKey("HighPointsLevel3");
        highPoints = 0;

        PlayerPrefs.DeleteKey("HighTimerLevel3");
        highTimer = 100000;


    }
}
