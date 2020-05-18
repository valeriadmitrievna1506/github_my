using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenu;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Debug.Log("hide pause");
                ResumeGame();
            } else
            {
                Debug.Log("show pause");
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        Paused = true;
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        Paused = false;
    }

    public void SaveMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(gameObject.GetComponent<CrossFade>().StartTransition());
        SceneManager.LoadScene("Menu");
    }

    public void SaveExit()
    {
        Time.timeScale = 1;
        StartCoroutine(gameObject.GetComponent<CrossFade>().StartTransition());
        Application.Quit();
    }

}
