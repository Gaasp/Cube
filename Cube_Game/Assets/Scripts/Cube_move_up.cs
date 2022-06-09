using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_move_up : MonoBehaviour
{
    public GameObject cube_up_down;
    public Animator animator;
    public Animation animation;
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
            //animator.SetBool();
            
        }
    }
}
