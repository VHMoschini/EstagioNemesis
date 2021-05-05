using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraConfiner : MonoBehaviour
{
	private CinemachineFreeLook freeLook;

	public float maxAngle;
	public float lerpCameraBack;
	
    void Start()
    {
		freeLook = GetComponent<CinemachineFreeLook>();
    }
	

    void Update()
    {
		if (freeLook.m_XAxis.Value > maxAngle)
		{
			freeLook.m_XAxis.Value = Mathf.Lerp(freeLook.m_XAxis.Value, maxAngle, lerpCameraBack);
		}
		else if (freeLook.m_XAxis.Value < -maxAngle)
		{
			freeLook.m_XAxis.Value = Mathf.Lerp(freeLook.m_XAxis.Value, -maxAngle, lerpCameraBack);
		}
	}
}
