using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBulletScript : MonoBehaviour
{
    public GameObject laser;
    private bool hitted;

	//public Material signalMaterial;
	public GameObject signalObject;

    private void OnTriggerEnter(Collider other)
    {
        if (!hitted)
        {
            GameObject LaserInst = Instantiate(laser, transform.position, transform.rotation);
            hitted = true;
        }
        Destroy(gameObject);
    }
/*
	private void Update()
	{
		signalMaterial.color = new Color(signalMaterial.color.r, signalMaterial.color.g, signalMaterial.color.b, Mathf.Abs(Mathf.Sin(Time.time)));
		signalObject.transform.rotation = Quaternion.identity;
	}*/
}
