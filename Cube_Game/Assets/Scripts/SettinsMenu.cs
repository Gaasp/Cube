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
    Resolution[] resolutions;
    public void Start()
    {
       resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i =0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
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
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
