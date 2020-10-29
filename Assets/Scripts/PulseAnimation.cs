using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseAnimation : MonoBehaviour
{
	private Vector3 originalScale;

	public float pulseSize;

	private void Start()
	{
		originalScale = transform.localScale;
	}

	void Update()
    {
		transform.localScale = originalScale  + pulseSize * Vector3.one * Mathf.Sin(Time.time);
    }
}
