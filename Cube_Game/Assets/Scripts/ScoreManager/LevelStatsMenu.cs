using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStatsMenu : MonoBehaviour
{
    public TMPro.TMP_Text levelText;
    public TMPro.TMP_Text timeText;
    public TMPro.TMP_Text pointsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Level1Stats()
    {
        levelText.text = "Level 1";
       // timeText.text = ScoreManager.instance.highTimer.ToString();
        pointsText.text = ScoreManager.instance.highPoints.ToString();
        if(ScoreManager.instance.highTimer == 100000)
        {
            timeText.text = "Time no set";
        }
        else
        {
            timeText.text = ScoreManager.instance.highTimer.ToString();
        }
    }
    public void Level2Stats()
    {
        levelText.text = "Level 2";
       // timeText.text = ScoreManagerLevel2.instance.highTimer.ToString();
        pointsText.text = ScoreManagerLevel2.instance.highPoints.ToString();
        if (ScoreManagerLevel2.instance.highTimer == 100000)
        {
            timeText.text = "Time no set";
        }
        else
        {
            timeText.text = ScoreManagerLevel2.instance.highTimer.ToString();
        }
    }
    public void Level3Stats()
    {
        levelText.text = "Level 3";
        //timeText.text = ScoreManagerLevel3.instance.highTimer.ToString();
        pointsText.text = ScoreManagerLevel3.instance.highPoints.ToString();
        if (ScoreManagerLevel3.instance.highTimer == 100000)
        {
            timeText.text = "Time no set";
        }
        else
        {
            timeText.text = ScoreManagerLevel3.instance.highTimer.ToString();
        }
    }
    public void Level4Stats()
    {
        levelText.text = "Level 4";
       // timeText.text = ScoreManagerLevel4.instance.highTimer.ToString();
        pointsText.text = ScoreManagerLevel4.instance.highPoints.ToString();
        if (ScoreManagerLevel4.instance.highTimer == 100000)
        {
            timeText.text = "Time no set";
        }
        else
        {
            timeText.text = ScoreManagerLevel4.instance.highTimer.ToString();
        }
    }
    public void Level5Stats()
    {
        levelText.text = "Level 5";
        //timeText.text = ScoreManagerLevel5.instance.highTimer.ToString();
        pointsText.text = ScoreManagerLevel5.instance.highPoints.ToString();
        if (ScoreManagerLevel5.instance.highTimer == 100000)
        {
            timeText.text = "Time no set";
        }
        else
        {
            timeText.text = ScoreManagerLevel5.instance.highTimer.ToString();
        }
    }

    public void ResetStats()
    {
        ScoreManager.instance.ResetStats();
        ScoreManagerLevel2.instance.ResetStats();
        ScoreManagerLevel3.instance.ResetStats();
        ScoreManagerLevel4.instance.ResetStats();
        ScoreManagerLevel5.instance.ResetStats();
    }

}
