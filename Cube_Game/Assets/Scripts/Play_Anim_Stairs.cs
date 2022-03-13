using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Anim_Stairs : MonoBehaviour
{
    [SerializeField] private Animator move_plate_anim;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            move_plate_anim.SetBool("Stairs_Move", true);
        }
    }
}
