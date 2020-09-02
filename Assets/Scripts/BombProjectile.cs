using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    public ParticleSystem explosionEffects;
    private bool hitted;


    private void OnCollisionEnter(Collision collision)
    {
        if (!hitted)
        {
            Instantiate(explosionEffects, transform.position, transform.rotation);
            GetComponent<SphereCollider>().enabled = true;
            Destroy(gameObject, 0.1f);
            hitted = true;
        }
    }



}
