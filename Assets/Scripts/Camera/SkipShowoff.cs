using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipShowoff : MonoBehaviour
{
	public static CameraShowoff script;


	private void OnMouseUp()
	{
		script.GoQuick();
		Destroy(gameObject);
	}
}
