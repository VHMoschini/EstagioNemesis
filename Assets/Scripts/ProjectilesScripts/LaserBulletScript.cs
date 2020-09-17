using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBulletScript : MonoBehaviour
{
    public GameObject laser;
    public BarsManager barsManager;

    private void OnTriggerEnter(Collider other)
    {
        GameObject LaserInst = Instantiate(laser, transform.position, transform.rotation);
        LaserInst.GetComponent<LaserScript>().barsManager = barsManager;
        Destroy(gameObject);
    }
}
