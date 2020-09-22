using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHighlight : MonoBehaviour
{
	public GameObject[] Ammos;

	public void ChangePosition(int index)
	{
		transform.position = Ammos[index].transform.position;
	}
}
