using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_connect : MonoBehaviour
{
    public GameObject player;
    public GameObject cube_attach;
    
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
            player.transform.SetParent(cube_attach.transform);
            StartCoroutine("wait");
          
        }
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
            cube_attach.transform.DetachChildren();
        }
    }
    IEnumerator wait()
    {
        yield return (new WaitForSeconds(0.5f));
        cube_attach.GetComponent<Cube_waypoint>().enabled = true;
    }
}
