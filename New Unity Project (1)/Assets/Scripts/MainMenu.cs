using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
//using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioMixer am;
    public bool isFullScreen = false;
    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown dropdown;

    public void NewGame()
    {
        StartCoroutine(gameObject.GetComponent<CrossFade>().loadLevel("Game1"));
    }

    public void Awake()
    {
        Cursor.visible = true;
        Screen.fullScreen = false;
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            if ((i.width > 700) && (i.height > 500)) {
                resolutions.Add(i.width + "x" + i.height);
            }
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }

    public void AudioVolume (float sv)
    {
        am.SetFloat("MainVolume", sv);
    }

    public void FullScreenToggle ()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void Resolution (int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }

    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }

    public void QuitButton()
    {
        StartCoroutine(gameObject.GetComponent<CrossFade>().StartTransition());
        Application.Quit();
    }

}
