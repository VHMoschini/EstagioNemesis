using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCoreGetInputTouchAxis : MonoBehaviour
{
	public float TouchSensitivity_x;
	public float TouchSensitivity_y;
	private CinemachineFreeLook cmFL;
	public float speed;
	
	void Start()
	{
		CinemachineCore.GetInputAxis = HandleAxisInputDelegate;
		cmFL = GetComponent<CinemachineFreeLook>();
		cmFL.m_XAxis.m_MaxSpeed = speed;
	}

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			cmFL.m_XAxis.m_MaxSpeed = speed;
		}
		else
		{
			cmFL.m_XAxis.m_MaxSpeed = 0;
		}
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
