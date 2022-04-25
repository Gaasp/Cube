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

    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        canvas = GameObject.Find("LevelComplete");
        canvas2 = canvas.GetComponent<Canvas>();
    }
    void OnTriggerExit(Collider other)
    {
        canvas2.enabled = true;
        other.isTrigger = true;
        playerMovement.movement_on_off = false;
        
    }

}
