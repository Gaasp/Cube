using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Over : MonoBehaviour
{
    PlayerMovement playerMovement;
    CameraMovement cameraMovement;
    Pause_Menui pause_Menui;
    float game_over_distanceY = -5;
    public GameObject player;
    public GameObject gameOverMenu;
    Vector3 spawnLocation;
    public float game_over_check = 0;
    // Start is called before the first frame update
    private void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        cameraMovement = GameObject.Find("Camera").GetComponent<CameraMovement>();
        spawnLocation = new Vector3(0f, 5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
      
        if (player.transform.position.y < game_over_distanceY)
        {
            gameOverMenu.SetActive(true);
            cameraMovement.enabled = false;
            game_over_check = 1;
            //playerMovement.falling = false;
            //odlaczenie camery
        }
    }
    public void Restart()
    {
        game_over_check = 0;
        player.transform.position = spawnLocation;
        cameraMovement.enabled = true;
        Time.timeScale = 1f;
        playerMovement.falling = false;
        gameOverMenu.SetActive(false);

    }

}
