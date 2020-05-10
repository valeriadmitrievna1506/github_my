using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public Animator anim;
    public bool paused = false;

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)    //pause
        {
            paused = true;
            StartCoroutine(StartPause());
        }
    }
    public void Back()
    {
        paused = false;
        StartCoroutine(CancelPause());
    }

    IEnumerator CancelPause()
    {
        Time.timeScale = 1;
        anim.SetBool("Paused", paused);
        Cursor.visible = paused;
        yield return new WaitForSeconds(1f);
        PauseMenu.SetActive(paused);
    }

    IEnumerator StartPause()
    {
        PauseMenu.SetActive(paused); ;
        anim.SetBool("Paused", paused);
        yield return new WaitForSeconds(1.01f);
        Cursor.visible = paused;
        paused = false;
        Time.timeScale = 0;
    }

    public void SaveandExittoMainMenu ()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveandExitGame ()
    {
        Application.Quit();
    }
}
