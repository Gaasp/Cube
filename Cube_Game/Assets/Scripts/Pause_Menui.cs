using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause_Menui : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Game_Pause = false;
    public GameObject player;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    PlayerMovement playerMovement;
    private Scene scene;
    public GameObject minimap_canvas;
    Game_Over game_Over;

    Timer timer;
    // Update is called once per frame
    void Update()
    {
        if (game_Over.game_over_check == 1)
        {

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Game_Pause)
                {
                    Resume();
                }
                else
                    Pause();
            }
        }
    }
    void Start()
    {
        game_Over = GameObject.Find("Player").GetComponent<Game_Over>();
        timer = GameObject.Find("Player").GetComponent<Timer>();
       scene = SceneManager.GetActiveScene();
       player = GameObject.Find("Player");
       playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        minimap_canvas = GameObject.Find("Canvas_Minimap");
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        minimap_canvas.SetActive(true);
        timer.timeText.gameObject.SetActive(true);
        playerMovement.scoreText.gameObject.SetActive(true);
        Time.timeScale = 1f;
        Game_Pause = false;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        minimap_canvas.SetActive(false);
        timer.timeText.gameObject.SetActive(false);
        playerMovement.scoreText.gameObject.SetActive(false);
        Time.timeScale = 0f;
        Game_Pause = true;
    }
    public void Restart()
    {
        if(scene.name == "Level 1")
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
       // player.transform.position = new Vector3(0f, 1f, 2f);
        Time.timeScale = 1f;
        Game_Pause = false;
        pauseMenu.SetActive(false);
        minimap_canvas.SetActive(true);
        timer.timeText.gameObject.SetActive(true);
        playerMovement.scoreText.gameObject.SetActive(true);

    }
    public void NextLevel()
    {
        if (scene.name == "Level 1")
            SceneManager.LoadScene("Level 2");
        if (scene.name == "Level 2")
            SceneManager.LoadScene("Level 3");
        if (scene.name == "Level 3")
            SceneManager.LoadScene("Level 4");
        if (scene.name == "Level 4")
            SceneManager.LoadScene("Level 5");
        if (scene.name == "Level 5")
            SceneManager.LoadScene("Level 6");
        if (scene.name == "Level 6")
            SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        playerMovement.movement_on_off = true;
        Game_Pause = false;
    }
    

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
   
    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
