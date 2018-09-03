using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObject : MonoBehaviour {

    public float explosionStrength = 100;

    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddExplosionForce(explosionStrength, this.transform.position, 5);
    }
}
