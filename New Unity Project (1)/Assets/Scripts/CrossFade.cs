using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFade : MonoBehaviour
{
    public Animator anim;
    public GameObject TransitionScreen;

    public IEnumerator StartLevel()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        TransitionScreen.SetActive(false);
    }

    void Awake()
    {
        if (TransitionScreen.activeSelf)  StartCoroutine(StartLevel());
    }

    public void StartTr()
    {
        StartCoroutine(StartTransition());
    }

    public IEnumerator StartTransition()
    {
        TransitionScreen.SetActive(true);
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
    }

}
