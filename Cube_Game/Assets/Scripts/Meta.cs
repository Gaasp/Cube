using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class Meta : MonoBehaviour
{
    public GameObject canvas;
    public Canvas canvas2;
    PlayerMovement playerMovement;
    Points points;
    Timer timeScript;
    public float newTime;
    public float oldTime;
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        timeScript = GameObject.Find("Player").GetComponent<Timer>();
       // points = GameObject.Find
        canvas = GameObject.Find("LevelComplete");
        canvas2 = canvas.GetComponent<Canvas>();
        oldTime = Save_Load.instance.activeSave.saveTime;
        
        
    }
    public void Update()
    {
        newTime = timeScript.t;
    }
    void OnTriggerExit(Collider other)
    {
        canvas2.enabled = true;
        other.isTrigger = true;
        playerMovement.movement_on_off = false;
        timeScript.Finnish();

        if (newTime < oldTime)
        {
            Save_Load.instance.activeSave.saveTime = timeScript.timeAmmount;
            Save_Load.instance.activeSave.savePoints = playerMovement.scoreValue;
            Save_Load.instance.Save();
        }
    }

}
