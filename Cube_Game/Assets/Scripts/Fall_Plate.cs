using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Plate : MonoBehaviour
{
    public GameObject objectToFall;
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
            StartCoroutine("Fall");
        }
    }
   
    IEnumerator Fall()
    {
        while (true)
        {
            yield return (new WaitForSeconds(1.5f));
            objectToFall.GetComponent<Rigidbody>().useGravity = true;
            yield return (new WaitForSeconds(3f));
            objectToFall.SetActive(false);
            objectToFall.GetComponent<Rigidbody>().useGravity = false;
        }

    }
}
