using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayMenu : MonoBehaviour
{
    // Start is called before the first frame update
  
    public void Level1()
    {
        SceneManager.LoadScene("Procedural_Level_First");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Demo_Scene");
    }
    
}
