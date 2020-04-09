using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer am;
    public bool isFS = false;

    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown dropdown;

    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }

    public void SetVolume(float sliderVolume)
    {
        am.SetFloat("volume", sliderVolume);
    }

    public void FullScreenToggle()
    {
        isFS = !isFS;
        Screen.fullScreen = isFS;
    }

    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFS);
    }

}
