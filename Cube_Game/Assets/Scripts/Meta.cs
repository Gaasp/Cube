using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class Meta : MonoBehaviour
{
    public GameObject canvas;
    public Canvas canvas2;
  
    void Start()
    {
        canvas = GameObject.Find("LevelComplete");
        canvas2 = canvas.GetComponent<Canvas>();
    } 
    void OnTriggerExit(Collider other)
    { 
        canvas2.enabled = true;

    }
   


}
