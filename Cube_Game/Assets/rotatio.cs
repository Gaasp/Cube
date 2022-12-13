using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatio : MonoBehaviour
{

    public GameObject rotate;
    public int rotationLocal = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotation();
    }
    private void rotation()
    {
        if (rotationLocal == 360)
        {
            rotationLocal = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (rotationLocal == 0)
            {
                rotationLocal = 90;
            }
            else if (rotationLocal == 90)
            {
                rotationLocal = 180;
            }
            else if (rotationLocal == 180)
            {
                rotationLocal = 270;
            }
           else if (rotationLocal == 270)
            {
                rotationLocal = 0;
            }
            rotate.transform.localRotation = Quaternion.Euler(0, rotationLocal, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
             if (rotationLocal == 360)
            {
                rotationLocal = 0;
            }
            else if (rotationLocal == 0)
            {
                rotationLocal = 270;
            }
            else if (rotationLocal == 270)
            {
                rotationLocal = 180;
            }
           else if (rotationLocal == 180)
            {
                rotationLocal = 90;
            }
            else if (rotationLocal == 90)
            {
                rotationLocal = 0;
            }
            rotate.transform.localRotation = Quaternion.Euler(0, rotationLocal, 0);
        }
    }
}
