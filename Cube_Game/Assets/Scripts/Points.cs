using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Points : MonoBehaviour
{
    public GameObject PointsCube;
    public Text scoreText;
    public static int scoreValue = 0;
        Text score;
    public void Start()
    {
        //PointsCube = GameObject.Find("Point");
        score = GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            scoreValue += 1;
            PointsCube.SetActive(false);
        }
    }
    private void Update()
    {
        scoreText.text= "Score: " + scoreValue;
    }
}
