using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ShotScript : MonoBehaviour
{

    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, 3);
    }

}
