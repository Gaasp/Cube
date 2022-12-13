using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Over : MonoBehaviour
{
    PlayerMovement playerMovement;
    CameraMovement cameraMovement;
    Pause_Menui pause_Menui;
    float game_over_distanceY = -5;
    float player_falling = -15;
    public GameObject player;
    public GameObject gameOverMenu;
    Vector3 spawnLocation;
    public float game_over_check = 0;
    private Scene scene;
    // Start is called before the first frame update
    private void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        cameraMovement = GameObject.Find("Camera").GetComponent<CameraMovement>();
        spawnLocation = new Vector3(0f, 5f, 2f);
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (player.transform.position.y < game_over_distanceY)
        {
            
            gameOverMenu.SetActive(true);
            cameraMovement.enabled = false;
            game_over_check = 1;
            if(player.transform.position.y < player_falling)
            {
                playerMovement.falling = false;
            }
            //playerMovement.falling = false;
            //odlaczenie camery
        }
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
        game_over_check = 0;
        //player.transform.position = spawnLocation;
        cameraMovement.enabled = true;
        Time.timeScale = 1f;
        playerMovement.falling = false;
        gameOverMenu.SetActive(false);

    }

}
