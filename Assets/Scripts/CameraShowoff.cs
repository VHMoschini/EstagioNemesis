using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShowoff : MonoBehaviour
{
	public CinemachineVirtualCamera cam;
	private CinemachineTrackedDolly TD;

	public BoolVariable shouldMoveCamera;
	private PlayerCharacterManager characterManager;
	private PlayerMovement playerMovement;

	public GameObject canvas;

	public float speed;


	private void Start()
	{
		TD = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
		shouldMoveCamera.Value = false;
		characterManager = GetComponent<PlayerCharacterManager>();
		playerMovement = GetComponent<PlayerMovement>();
		playerMovement.follow = false;
	}

	private void Update()
	{
		
		TD.m_PathPosition += speed * Time.timeScale;

		
		if (TD.m_PathPosition > 3)
		{
			cam.m_LookAt = characterManager.playerInst.transform;
			
		}
		if (TD.m_PathPosition > 4)
		{
			cam.Priority = 0;
		}
		if (TD.m_PathPosition > 5f)
		{
			shouldMoveCamera.Value = true;
			playerMovement.SetupPosition();
			playerMovement.follow = true;
			canvas.SetActive(true);
			this.enabled = false;
		}
	}
}
