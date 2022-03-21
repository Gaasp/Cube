using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach_player_plate : MonoBehaviour
{
    public GameObject player;
    public GameObject plate;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.name == "Player")
        {
            player.transform.SetParent(plate.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.name == "Player")
        {
            plate.transform.DetachChildren();
        }
    }

}
