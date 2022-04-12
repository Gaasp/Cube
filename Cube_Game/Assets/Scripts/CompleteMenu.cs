using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CompleteMenu : MonoBehaviour
{
    public GameObject canvas;
    public Canvas canvas2;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("LevelComplete");
        canvas2 = canvas.GetComponent<Canvas>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Demo_Scene");
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        canvas2.enabled = false;
        player.transform.position = new Vector3(0f, 1f, 2f);
        Time.timeScale = 1f;
        
    }
    public void Reset()
    {
        SceneManager.LoadScene("Procedural_Level_First");
        Time.timeScale = 1f;
    }
    public void Back_To_Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
