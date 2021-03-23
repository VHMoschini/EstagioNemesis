using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShowoff : MonoBehaviour
{
	public CinemachineVirtualCamera cam;
	private CinemachineTrackedDolly TD;
	private CinemachineBrain brain;

	public BoolVariable shouldMoveCamera;
	private PlayerCharacterManager characterManager;
	private PlayerMovement playerMovement;

	public GameObject canvas;

	public float speed;
	private float quickSpeed;

	public static bool quickShowoff;


	private void Start()
	{
		TD = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
		shouldMoveCamera.Value = false;
		characterManager = GetComponent<PlayerCharacterManager>();
		playerMovement = GetComponent<PlayerMovement>();
		playerMovement.follow = false;
		quickSpeed = speed * 5;
		brain = Camera.main.GetComponent<CinemachineBrain>();

		if (quickShowoff) speed = quickSpeed;

		Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
			var dependencyStatus = task.Result;
			if (dependencyStatus == Firebase.DependencyStatus.Available)
			{
				// Create and hold a reference to your FirebaseApp,
				// where app is a Firebase.FirebaseApp property of your application class.
				var app = Firebase.FirebaseApp.DefaultInstance;

				// Set a flag here to indicate whether Firebase is ready to use by your app.
			}
			else
			{
				UnityEngine.Debug.LogError(System.String.Format(
				  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
				// Firebase Unity SDK is not safe to use here.
			}
		});
	}

	private void Update()
	{
		
		TD.m_PathPosition += speed * Time.timeScale;

		
		if (TD.m_PathPosition > 3)
		{
			cam.m_LookAt = characterManager.playerInst.transform;

			if (TD.m_PathPosition > 4)
			{
				cam.Priority = 0;
				speed = quickSpeed;
				quickShowoff = true;

				if (brain.ActiveVirtualCamera.VirtualCameraGameObject != cam.gameObject && brain.ActiveBlend == null)
				{
					shouldMoveCamera.Value = true;
					playerMovement.SetupPosition();
					playerMovement.follow = true;
					canvas.SetActive(true);
					this.enabled = false;
				}
			}
		}
		
		
	}
}
