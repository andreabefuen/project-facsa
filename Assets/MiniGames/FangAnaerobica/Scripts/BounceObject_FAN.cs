﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//objeto que hace rebotar la pelota
public class BounceObject_FAN : MonoBehaviour {

    public float explosionStrength = 100;

    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddExplosionForce(explosionStrength, this.transform.position, 5);
    }
}
