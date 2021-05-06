using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToSelfdestruct : MonoBehaviour
{
	public float time;

	private void Start()
	{
		StartCoroutine(Selfdestruct());
	}


	private IEnumerator Selfdestruct()
	{
		yield return new WaitForSeconds(time);

		Destroy(gameObject);
	}
}
