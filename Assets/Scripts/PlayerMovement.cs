using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public GameObject cam;
	public bool follow;

	private Vector3 startingPos;

	public BoolVariable shouldMoveCam;
	public FloatVariable TouchDistanceDelta;


	

	

	private void Start()
	{
		transform.parent = cam.transform;
		transform.rotation = cam.transform.rotation;
		startingPos = transform.localPosition;
	}

	private void Update()
	{
		if (follow)
		{
			transform.parent = cam.transform;
			transform.localPosition = Vector3.Lerp(transform.localPosition, startingPos, 0.5f);
			transform.rotation = Quaternion.Slerp(transform.rotation, cam.transform.rotation, 0.2f);
		}
		else
		{
			transform.parent = null;
		}




		
		
	}

}
