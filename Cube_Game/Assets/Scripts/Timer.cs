using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public TMPro.TMP_Text timeText;
    private float startTime;
    public float timeAmmount;
    public bool finished = false;
    Game_Over game_Over;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        game_Over = GameObject.Find("Player").GetComponent<Game_Over>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished || game_Over.game_over_check == 1)
        {
            startTime = Time.time;
            return;
        }
        t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f3");
        timeText.text = minutes + ":" + seconds;
    }
    public void Finnish()
    {
        finished = true;
        timeAmmount = t;
        timeText.color = Color.yellow;
        
    }

}
