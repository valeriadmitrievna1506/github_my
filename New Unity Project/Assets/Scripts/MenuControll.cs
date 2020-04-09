using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControll : MonoBehaviour
{
    public Animator[] anim = new Animator[4];           //0 - play
    public GameObject MainMenu;                         //1 - options
    public GameObject OptionsTitle;                     //2 - quit
                                                        //3 - baack


    ///----------PLAY----------//
    public void PlayPressed()
    {
        anim[0].SetBool("pressed", true);
        StartCoroutine(play());
    }
    IEnumerator play()
    {
        yield return new WaitForSeconds(0.3f);
        Debug.Log("PLAY!");
        SceneManager.LoadScene("Game1");
    }

    //----------OPTIONS----------//
    public void OptionsPressed()
    {
        anim[1].SetBool("pressed", true);
        StartCoroutine(options());
    }
    IEnumerator options()
    {
        yield return new WaitForSeconds(0.3f);
        MainMenu.SetActive(false);
        OptionsTitle.SetActive(true);
    }

    //----------BACK----------//
    public void BackPressed()
    {
        anim[3].SetBool("pressed", true);
        StartCoroutine(back());
    }
    IEnumerator back()
    {
        yield return new WaitForSeconds(0.3f);
        MainMenu.SetActive(true);
        OptionsTitle.SetActive(false);
    }

    //----------QUIT----------//
    public void QuitPressed()
    {
        anim[2].SetBool("pressed", true);
        StartCoroutine(quit());
    }
    IEnumerator quit()
    {
        yield return new WaitForSeconds(0.3f);
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
