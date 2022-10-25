using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
   
    public static CameraMove cameraMove;
    public GameObject targetObject;
    public PlayerMovement playerMovement;
    public GameObject player;
    public int targetAngle = 0;
    const int rotationAmount = 1;
   float rotationAngle = 90f;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
            // Trigger functions if Rotate is requested
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                targetAngle -= 90;
            //if (rotationLocal == 0)
            //{
            //    rotationLocal = 90;
            //}
            //if (rotationLocal == 90)
            //{
            //    rotationLocal = 180;
            //}
            //if (rotationLocal == 180)
            //{
            //    rotationLocal = 270;
            //}
            //if (rotationLocal == 360)
            //{
            //    rotationLocal = 0;
            //}
            //rotate.transform.localRotation = Quaternion.Euler(0, rotationLocal, 0);

        }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {           
            targetAngle += 90;
            //if (rotationLocal == 360)
            //{
            //    rotationLocal = 0;
            //}
            //if (rotationLocal == 0)
            //{
            //    rotationLocal = 270;
            //}
            //if (rotationLocal == 270)
            //{
            //    rotationLocal = 180;
            //}
            //if (rotationLocal == 180)
            //{
            //    rotationLocal = 90;
            //}
            //if (rotationLocal == 90)
            //{
            //    rotationLocal = 0;
            //}
            //rotate.transform.localRotation = Quaternion.Euler(0, rotationLocal, 0);
        }

            if (targetAngle != 0)
            {
                Rotate();
            }

        }


   
    protected void Rotate()
    {

        if (targetAngle > 0)
        {
            transform.RotateAround(targetObject.transform.position, Vector3.up, -rotationAmount);
            targetAngle -= rotationAmount;
        }
        else if (targetAngle < 0)
        {
            transform.RotateAround(targetObject.transform.position, Vector3.up, rotationAmount);
            targetAngle += rotationAmount;
        }

    }
    

}