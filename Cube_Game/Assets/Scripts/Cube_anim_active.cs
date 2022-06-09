using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_anim_active : MonoBehaviour
{
    public GameObject cube_enable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            if (other.gameObject.name == "Player")
            {
                cube_enable.SetActive(true);
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
      
    }
}
