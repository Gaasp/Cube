using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Pause : MonoBehaviour
{
    public float zoomSize = 5;
    public float moveSpeed;
    public float zoomSpeed;
    
    public float minZoomDist;
    public float maxZoomDist;
  
    public Camera cam;
    
    public bool pause = false;
    private float DefaultCamSize = 3.6f;

    public GameObject player;
    PlayerMovement playerMovement;
    CameraMovement cameraMovement;
    public GameObject active_Pause;
   
    private void Awake()
    {
        cam = Camera.main;
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        player = GameObject.Find("PlayerModel");
    }
    // Start is called before the first frame update
    void Start()
    {
        active_Pause = GameObject.Find("Pause_Text");
    }

    // Update is called once per frame
    void Update()
    {

       

        if (Input.GetKeyDown(KeyCode.Space)) // Pause
        {
            if (pause)
            {
                active_Pause.GetComponent<Canvas>().enabled = false;
                pause = false;
                playerMovement.movement_on_off = true;
                cam.GetComponent<CameraMovement>().enabled = true;
            }
            else
            {
                active_Pause.GetComponent<Canvas>().enabled = true;
                pause = true;
                playerMovement.movement_on_off = false;
                cam.GetComponent<CameraMovement>().enabled = false;
            }
        }
        Move();
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCamera();
        }
        
    }
    private void LateUpdate()
    {
        Zoom();
    }
    void ResetCamera()
    {
        Vector3 reset = new Vector3(0.5f, 0.5f, 0f);
        cam.orthographicSize = DefaultCamSize;
        transform.position =  player.transform.position + reset;

    }
    void Zoom()
    {
        
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
     
        if (scrollInput > 0.0f)
        {
            if (cam.orthographicSize >= minZoomDist)
            {
                cam.orthographicSize -= Time.deltaTime * zoomSpeed;
            }
        }
        if(scrollInput < 0.0f)
        {

            if (cam.orthographicSize <= maxZoomDist)
            {
                cam.orthographicSize += Time.deltaTime * zoomSpeed;
            }
        }
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = transform.up * zInput + transform.right * xInput;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
   
    public void FocusOnPossition(Vector3 pos)
    {
        transform.position = pos;
    }
}
