using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public GameObject cam;
	public bool follow;

	private Vector3 startingPos;
	

	private void Start()
	{
		transform.parent = cam.transform;
		transform.rotation = Quaternion.Euler(0, cam.transform.rotation.y, cam.transform.localRotation.z);
		startingPos = transform.localPosition;
	}

	private void Update()
	{
		if (follow)
		{
			transform.parent = cam.transform;
			transform.localPosition = Vector3.Lerp(transform.localPosition, startingPos, 0.5f);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(-17, 0, 0), 0.2f);
		}
		else
		{
			transform.parent = null;
		}	
		
	}

}
