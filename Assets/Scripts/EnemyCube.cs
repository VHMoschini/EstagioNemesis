﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : MonoBehaviour
{
	private bool isGrounded;
	//private bool wasHit;
	private Vector3 startingPos;


	public float timerToDie;
	public GameObject debris;
	
    void Start()
    {
		startingPos = transform.position;
		debris = Resources.Load<GameObject>("Debris");
    }
	

	private void OnCollisionEnter(Collision collision)
	{

		if (Vector3.Distance(startingPos, transform.position) > 1 && collision.collider.CompareTag("Ground"))
		{
			isGrounded = true;
			StartCoroutine(TurnToRubble(collision.GetContact(0).point.y));
		}
		//else if (collision.collider.CompareTag("Bullet"))
		//{
		//	wasHit = true;
		//}

	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.CompareTag("Ground"))
		{
			isGrounded = false;
		}
	}


	private IEnumerator TurnToRubble(float hitPos)
	{
		yield return new WaitForSeconds(timerToDie);
		if (isGrounded)
		{
            GetComponentInParent<BarsManager>().hittedEnemieCubes++;
			Instantiate(debris, new Vector3(transform.position.x, hitPos, transform.position.z), Quaternion.identity, null);
			Destroy(gameObject);
		}
	}
}
