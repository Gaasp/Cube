using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause_Menui : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool Game_Pause = false;
    public GameObject player;
    public GameObject pauseMenu;
    private Scene scene;
    // Update is called once per frame
    void Update()
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
    void Start()
    {
       scene = SceneManager.GetActiveScene();
       player = GameObject.Find("Player");
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Game_Pause = false;
    }
    public void Restart()
    {
        player.transform.position = new Vector3(0f, 1f, 2f);
        Time.timeScale = 1f;
        Game_Pause = false;
        pauseMenu.SetActive(false);

    }
    public void Reset()
    {
        if (scene.name == "Procedural_Level_First")
            SceneManager.LoadScene("Procedural_Level_First");
        if (scene.name == "Demo_Scene")
            SceneManager.LoadScene("Demo_Scene");
        Time.timeScale = 1f;
        Game_Pause = false;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Game_Pause = true;
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
