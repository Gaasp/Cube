using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_cube_change : MonoBehaviour
{
    public Color[] colorBank;
    public MeshRenderer m;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
       
        m = GetComponent<MeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ColorChangePlayer()
    {

    }
    void OnMouseDown()
    {
        if (m != null)
        {
            Color color = new Color
            (
                Random.value, Random.value, Random.value
            );
        }
    }
}
