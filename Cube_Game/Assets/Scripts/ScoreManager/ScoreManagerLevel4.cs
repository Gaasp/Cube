using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerLevel4 : MonoBehaviour
{
    public static ScoreManagerLevel4 instance;

    public int points, highPoints;
    public float timer, highTimer;
    

    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("HighPointsLevel4"))
        {
            highPoints = PlayerPrefs.GetInt("HighPointsLevel4");
        }
        
        if (PlayerPrefs.HasKey("HighTimerLevel4"))
        {
            highTimer = PlayerPrefs.GetFloat("HighTimerLevel4");
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
        PlayerPrefs.SetFloat("HighTimerLevel4", highTimer);
    }
    public void UpdateHighPoints()
    {
        if (points > highPoints)
        {
            highPoints = points;

            PlayerPrefs.SetInt("HighPointsLevel4", highPoints);
        }
    }
    public void ResetScore()
    {
        points = 0;
    }

    public void ResetStats()
    {
        PlayerPrefs.DeleteKey("HighPointsLevel4");
        highPoints = 0;

        PlayerPrefs.DeleteKey("HighTimerLevel4");
        highTimer = 100000;
    }
}
