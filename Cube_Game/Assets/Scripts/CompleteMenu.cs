using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CompleteMenu : MonoBehaviour
{
    public GameObject canvas;
    public Canvas canvas2;
    public GameObject player;
    private Scene scene;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        canvas = GameObject.Find("LevelComplete");
        canvas2 = canvas.GetComponent<Canvas>();
        player = GameObject.Find("Player");
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel()
    {
        if (scene.name == "Level 1")
            SceneManager.LoadScene("Level 2");
        if (scene.name == "Level 2")
            SceneManager.LoadScene("Level 3");
        if (scene.name == "Level 3")
            SceneManager.LoadScene("Level 4");
        if (scene.name == "Level 5")
            SceneManager.LoadScene("Level 6");
        if (scene.name == "Level 6")
            SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        playerMovement.movement_on_off = true;
    }
    public void Restart()
    {
        if (scene.name == "Level 1")
        {
            SceneManager.LoadScene("Level 1");
        }
        if (scene.name == "Level 2")
        {
            SceneManager.LoadScene("Level 2");
        }
        if (scene.name == "Level 3")
        {
            SceneManager.LoadScene("Level 3");
        }
        if (scene.name == "Level 4")
        {
            SceneManager.LoadScene("Level 4");
        }
        if (scene.name == "Level 5")
        {
            SceneManager.LoadScene("Level 5");
        }
        if (scene.name == "Level 6")
        {
            SceneManager.LoadScene("Level 6");
        }
        playerMovement.movement_on_off = true;
        canvas2.enabled = false;
       
        Time.timeScale = 1f;
        
    }    
    
    public void Back_To_Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        
    }
}
