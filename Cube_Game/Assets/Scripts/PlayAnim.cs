using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    [SerializeField] private Animator move_plate_anim;
    // Start is called before the first frame update
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player")
        {
            move_plate_anim.SetBool("play_anim", true);
        }
    }
}
