using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossFade : MonoBehaviour
{
    public Animator transition;
    float transitionTime = 1f;

    public IEnumerator StartTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }

    public IEnumerator loadLevel (string levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

}
