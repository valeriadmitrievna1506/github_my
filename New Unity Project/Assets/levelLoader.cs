using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    public Animator transition;

    public void LoadScene()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator loadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }

}
