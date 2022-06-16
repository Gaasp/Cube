using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Stats : MonoBehaviour
{
    public string level;
    public float time;
    public int points;
    public double seed;

    public TMPro.TMP_Text levelText;
    public TMPro.TMP_Text timeText;
    public TMPro.TMP_Text pointsText;
    public TMPro.TMP_Text seedText;


    public void Update()
    {
        //levelText.text = level;
        timeText.text = time.ToString();
        pointsText.text = points.ToString();
        seedText.text = seed.ToString();
    }
    public void Start()
    {
        //if (Save_Load.instance.hasLoaded)
        //{
        level = Save_Load.instance.activeSave.saveLevelName;
        time = Save_Load.instance.activeSave.saveTime;
        points = Save_Load.instance.activeSave.savePoints;
        seed = Save_Load.instance.activeSave.saveSeed;
        //}

    }
    public void Level1()
    {
      
    }
    
}
