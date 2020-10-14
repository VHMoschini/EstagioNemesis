using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAiming : MonoBehaviour
{
	[SerializeField] private GameObject stopaiming;

	private bool mouseIsOn;

	private void Start()
	{
		stopaiming.SetActive(false);
	}

	private void Update()
	{
		if (mouseIsOn)
		{
			if (PlayerController.isAiming)
			{
				stopaiming.SetActive(true);
				PlayerController.shouldShoot = false;
			}
		}
		else
		{
			stopaiming.SetActive(false);
			PlayerController.shouldShoot = true;
		}
		mouseIsOn = false;
	}
	private void OnMouseEnter()
	{
		mouseIsOn = true;
	}
	private void OnMouseOver()
	{
		if (PlayerController.isAiming)
		{
			mouseIsOn = true;
		}
	}
	private void OnMouseExit()
	{
	}

	private void OnMouseUp()
	{
		stopaiming.SetActive(false);
		PlayerController.shouldShoot = true;
		Debug.Log("foi");
	}
}
