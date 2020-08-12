using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{

    public static SoundEffector Instance;

    public AudioClip shoot;
    //public AudioClip walking;
    public AudioClip recharge;


    private void Awake()
    {
        //регистрируем синглтон
        if (Instance != null)
        {
            Debug.LogError("Несколько экземпляров SoundEffector!");
        }
        Instance = this;
    }

    public void MakeShootSound()
    {
        MakeSound(shoot);
    }

    public void MakeReChargeSound()
    {
        MakeSound(recharge);
    }

    //Играть данный звук
    public void MakeSound(AudioClip original)
    {
        AudioSource.PlayClipAtPoint(original, transform.position);
    }

}
