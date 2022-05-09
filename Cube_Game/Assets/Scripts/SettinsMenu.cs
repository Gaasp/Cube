using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettinsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    //public Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown resolutionDropdown;
   
   
    //Audio
    public void Set_Master_Volume(float master_volume)
    {
        audioMixer.SetFloat("Master", master_volume); 
    }
    public void Set_Music_Volume(float music_volume)
    {
        audioMixer.SetFloat("Music", music_volume);
    }
    public void Set_Effects_Volume(float effects_volume)
    {
        audioMixer.SetFloat("Effects", effects_volume);
    }

    //Video

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //Fullscreen
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    //Resolution
    List<int> widths = new List<int>() { 568, 960, 1024, 1280, 1920 };
    List<int> heights = new List<int>() { 320, 540, 768, 800, 1080 };
    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];

        Screen.SetResolution(width, height, fullscreen);
    }
}
