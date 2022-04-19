using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Pause : MonoBehaviour
{
    public float moveSpeed;
    public float zoomSpeed;

    public float minZoomDist;
    public float maxZoomDist;

    public Camera cam;
    
    public bool pause = false;

    PlayerMovement playerMovement;
    private void Awake()
    {
        cam = Camera.main;
        
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) // Pause
        {
            if (pause)
            {
               // Time.timeScale = 1f;
                pause = false;
                playerMovement.movement_on_off = true;
                cam.GetComponent<CameraMovement>().enabled = true;
            }
            else
            {
                //Time.timeScale = 0f;
                pause = true;
                playerMovement.movement_on_off = false;
               cam.GetComponent<CameraMovement>().enabled = false;
            }
        }
        Move();
    }
    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = transform.up * zInput + transform.right * xInput;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}