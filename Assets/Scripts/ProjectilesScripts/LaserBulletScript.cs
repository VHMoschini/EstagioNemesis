using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBulletScript : MonoBehaviour
{
    public GameObject laser;
    private bool hitted;

    private void OnTriggerEnter(Collider other)
    {
        if (!hitted)
        {
            GameObject LaserInst = Instantiate(laser, transform.position, transform.rotation);
            hitted = true;
        }
        Destroy(gameObject);
    }
}
