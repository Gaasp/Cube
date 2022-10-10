using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class videoControlMenu : MonoBehaviour
{
    public VideoPlayer vid1;
    public VideoPlayer vid2;
 
 
void Start() 
    {
        vid1.loopPointReached += CheckOver;
        vid2.loopPointReached += CheckOver;
    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
    }

}

