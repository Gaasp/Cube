using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Meta : MonoBehaviour
{
    Scene sceneActive;
    public GameObject canvas;
    public Canvas canvas2;
    PlayerMovement playerMovement;
    Points points;
    Timer timeScript;
    public float newTime;
    public float oldTime;
    void Start()
    {
        sceneActive = SceneManager.GetActiveScene();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        timeScript = GameObject.Find("Player").GetComponent<Timer>();
       // points = GameObject.Find
        canvas = GameObject.Find("LevelComplete");
        canvas2 = canvas.GetComponent<Canvas>();
       
        
        
    }
    public void Update()
    {
        newTime = timeScript.t;
    }
    void OnTriggerEnter(Collider other)
    {
        canvas2.enabled = true;
        other.isTrigger = true;
        playerMovement.movement_on_off = false;
        timeScript.Finnish();
        if(sceneActive.name == "Level 1")
        {
            if (ScoreManager.instance.timer < ScoreManager.instance.highTimer)
                {
                    ScoreManager.instance.UpdateHighTimer();
                    ScoreManager.instance.UpdateHighPoints();
                }
        }
        if (sceneActive.name == "Level 2")
        {
            if (ScoreManagerLevel2.instance.timer < ScoreManagerLevel2.instance.highTimer)
                {
                    ScoreManagerLevel2.instance.UpdateHighTimer();
                    ScoreManagerLevel2.instance.UpdateHighPoints();
                }
        }
        if (sceneActive.name == "Level 3")
            {
            if (ScoreManagerLevel3.instance.timer < ScoreManagerLevel3.instance.highTimer)
            {
                ScoreManagerLevel3.instance.UpdateHighTimer();
                ScoreManagerLevel3.instance.UpdateHighPoints();
            }
        }
        if (sceneActive.name == "Level 4")
            {
            if (ScoreManagerLevel4.instance.timer < ScoreManagerLevel4.instance.highTimer)
            {
                ScoreManagerLevel4.instance.UpdateHighTimer();
                ScoreManagerLevel4.instance.UpdateHighPoints();
            }
        }
        if (sceneActive.name == "Level 5")
            {
            if (ScoreManagerLevel5.instance.timer < ScoreManagerLevel5.instance.highTimer)
            {
                ScoreManagerLevel5.instance.UpdateHighTimer();
                ScoreManagerLevel5.instance.UpdateHighPoints();
            }
        }    
    }
}
