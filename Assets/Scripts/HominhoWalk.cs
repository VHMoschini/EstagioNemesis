using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HominhoWalk : MonoBehaviour
{
	private NavMeshAgent agent;
	private BoxCollider parent;

	public float wanderSpeed;

	private Vector3 targetPosition;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		parent = transform.parent.GetComponent<BoxCollider>();
		NewPositionToGo();
		transform.position = targetPosition;

	}

	private void Update()
	{
		agent.SetDestination(targetPosition);
		agent.speed = wanderSpeed;


		if (Random.Range(0,200) >= 195) NewPositionToGo();
	}

	private void NewPositionToGo()
	{
		targetPosition = new Vector3(Random.Range(parent.bounds.min.x, parent.bounds.max.x), 0, Random.Range(parent.bounds.min.z, parent.bounds.max.z));
	}
}
