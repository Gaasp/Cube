using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Points : MonoBehaviour
{
    //public TMP_Text scoreText;
    public TMPro.TMP_Text scoreText;
    public GameObject PointsCube;
    
    public int scoreValue = 0;
        Text score;
    public void Start()
    {
        scoreText = TMP_Text.FindObjectOfType<TMP_Text>();

        //TextMeshPro scoreText = GetComponent<TextMeshPro>();
        //scoreText = TextMeshPro.FindObjectOfType(scoreText);
        //PointsCube = GameObject.Find("Point");
        score = GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerModel")
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
