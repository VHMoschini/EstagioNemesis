using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class CinemachineCoreGetInputTouchAxis : MonoBehaviour
{
	public float TouchSensitivity_x;
	public float TouchSensitivity_y;
	private CinemachineFreeLook cmFL;
	public float speed;

	public BoolVariable shouldMove;
	public float touchDistanceDelta;


	private float dist;
	private float oldDist;

	private Vector2 basePosition;
	private Touch[] touchesCount;

	private bool antiSnap;


	void Start()
	{
		CinemachineCore.GetInputAxis = HandleAxisInputDelegate;
		cmFL = GetComponent<CinemachineFreeLook>();
		cmFL.m_XAxis.m_MaxSpeed = speed;
	}

	private void Update()
	{
		if (Input.GetMouseButton(0) && shouldMove.Value)
		{
			if (Input.touchCount > 1)
			{
				
				basePosition = new Vector2(0, 0);



				dist = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
				touchDistanceDelta = dist - oldDist;

				if (!antiSnap)
				{
					Zoom(touchDistanceDelta / 15);
				}
				antiSnap = false;
				

				oldDist = dist;
			}
			else
			{
				cmFL.m_XAxis.m_MaxSpeed = speed;
				antiSnap = true;
			}
		}
		else
		{
			cmFL.m_XAxis.m_MaxSpeed = 0;
			antiSnap = true;
		}
	}

	void Zoom(float increment)
	{
		cmFL.m_Orbits[1].m_Height = Mathf.Clamp(cmFL.m_Orbits[1].m_Height - increment, 25, 35);
		cmFL.m_Orbits[1].m_Radius = Mathf.Clamp(cmFL.m_Orbits[1].m_Radius - increment, 50, 70);

	}

	float HandleAxisInputDelegate(string axisName)
	{
		switch (axisName)
		{

			case "Mouse X":

				if (Input.touchCount > 0)
				{
					return Input.touches[0].deltaPosition.x / TouchSensitivity_x;
				}
				else
				{
					return Input.GetAxis(axisName);
				}

			case "Mouse Y":
				if (Input.touchCount > 0)
				{
					return Input.touches[0].deltaPosition.y / TouchSensitivity_y;
				}
				else
				{
					return Input.GetAxis(axisName);
				}

			default:
				Debug.LogError("Input <" + axisName + "> not recognyzed.", this);
				break;
		}

		return 0f;
	}
}
