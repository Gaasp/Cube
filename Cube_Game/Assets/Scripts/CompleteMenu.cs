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
        if (scene.name == "Procedural_Level_First")
            SceneManager.LoadScene("Demo_Scene");
        if (scene.name == "Demo_Scene")
            SceneManager.LoadScene("Procedural_Level_First");
        Time.timeScale = 1f;
        playerMovement.movement_on_off = true;
    }
    public void Restart()
    {
        playerMovement.movement_on_off = true;
        canvas2.enabled = false;
        player.transform.position = new Vector3(0f, 1f, 2f);
        Time.timeScale = 1f;
        
    }
    public void Reset()
    {
        playerMovement.movement_on_off = true;
        Time.timeScale = 1f;
        if (scene.name == "Procedural_Level_First")
            SceneManager.LoadScene("Procedural_Level_First");
        if (scene.name == "Demo_Scene")
            SceneManager.LoadScene("Demo_Scene");
        
    }
    public void Back_To_Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        
    }
}
