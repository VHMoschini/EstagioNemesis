using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleForceFieldPositioner : MonoBehaviour
{
	private GameObject player;

	void Start()
	{
		transform.position = Camera.main.ScreenToWorldPoint(transform.position);
		player = FindObjectOfType<PlayerCharacterManager>().gameObject;
		transform.parent = player.transform;
	}
}
