using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer am;
    public void SetVolume(float sliderVolume)
    {
        am.SetFloat("volume", sliderVolume);
    }
}
