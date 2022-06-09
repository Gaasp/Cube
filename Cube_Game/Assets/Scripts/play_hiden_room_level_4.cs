using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_hiden_room_level_4 : MonoBehaviour
{
    public GameObject fall_cubes;
    public GameObject open_doors1;
    public GameObject open_doors2;
    public GameObject open_doors3;
    public GameObject open_doors4;
    public GameObject open_doors5;
    public GameObject open_doors6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            fall_cubes.SetActive(true);
            open_doors1.GetComponent<Cube_waypoint>().enabled = true;
            open_doors2.GetComponent<Cube_waypoint>().enabled = true;
            open_doors3.GetComponent<Cube_waypoint>().enabled = true;
            open_doors4.GetComponent<Cube_waypoint>().enabled = true;
            open_doors5.GetComponent<Cube_waypoint>().enabled = true;
            open_doors6.GetComponent<Cube_waypoint>().enabled = true;

        }
    }
}
