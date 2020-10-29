using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleForceFieldPositioner : MonoBehaviour
{
	private GameObject player;
	private GameObject originalParent;

	void Start()
	{
		originalParent = transform.parent.gameObject;
		transform.position = Camera.main.ScreenToWorldPoint(originalParent.transform.position + Vector3.forward * 30);
		player = FindObjectOfType<PlayerCharacterManager>().gameObject;
		transform.parent = player.transform;
	}

	private void Update()
	{
		transform.position = Camera.main.ScreenToWorldPoint(originalParent.transform.position+ Vector3.forward * 30);
	}
}
