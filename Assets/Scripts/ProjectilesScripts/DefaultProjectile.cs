using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
	{
		StartCoroutine(DestroyBullet(1f));
	}

	private IEnumerator DestroyBullet(float tempo)
	{
		yield return new WaitForSeconds(tempo);
		if (transform.childCount > 0)
		{
			Transform child = transform.GetChild(0);
			Destroy(child.gameObject, tempo);
			child.SetParent(null);
		}
		Destroy(gameObject);
	}
}
