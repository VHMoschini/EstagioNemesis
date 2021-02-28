using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HominhoWalk : MonoBehaviour
{
	private NavMeshAgent agent;
	private BoxCollider parent;

	public float wanderSpeed;
	public float runSpeed;

	private Vector3 targetPosition;
	private Vector3 abrigoPosition;

	public float distanceFromAbrigoToDespawn;

	public static bool isAfraid;

	private void Start()
	{
		isAfraid = false;
		agent = GetComponent<NavMeshAgent>();
		parent = transform.parent.GetComponent<BoxCollider>();
		NewPositionToGo();
		transform.position = targetPosition;
		abrigoPosition = transform.parent.GetChild(0).transform.position;

	}

	private void Update()
	{
		if (!isAfraid)
		{
			agent.SetDestination(targetPosition);
			agent.speed = wanderSpeed;

			if (Random.Range(0, 200) >= 195) NewPositionToGo();
		}

		else
		{
			agent.SetDestination(abrigoPosition);
			agent.speed = runSpeed;

			if(Vector3.Distance(transform.position, abrigoPosition) < distanceFromAbrigoToDespawn){
				gameObject.SetActive(false);
			}
		}
		

	}

	private void NewPositionToGo()
	{
		targetPosition = new Vector3(Random.Range(parent.bounds.min.x, parent.bounds.max.x), 0, Random.Range(parent.bounds.min.z, parent.bounds.max.z));
	}
}
