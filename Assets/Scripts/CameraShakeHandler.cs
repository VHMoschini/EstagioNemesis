using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShakeHandler : MonoBehaviour
{

	public static CameraShakeHandler Instance { get; private set; }

	private CinemachineFreeLook freeLook;
	private float shakeTimer;
	private float shakeTimerTotal;
	private float startingIntensity;
	public CinemachineBasicMultiChannelPerlin multiChannelPerlin;

	private void Awake()
	{
		Instance = this;
		freeLook = GetComponent<CinemachineFreeLook>();
	}

	public void ShakeCamera(float intensity, float time)
	{
		 multiChannelPerlin = freeLook.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

		multiChannelPerlin.m_AmplitudeGain = intensity;
		startingIntensity = intensity;
		shakeTimer = time;
		shakeTimerTotal = time;

	}

	private void Update()
	{
		if (shakeTimer > 0)
		{
			shakeTimer -= Time.deltaTime;
			
			multiChannelPerlin.m_AmplitudeGain = 
				Mathf.Lerp(startingIntensity, 0.5f, 1 - (shakeTimer / shakeTimerTotal));
			
		}
	}
}
