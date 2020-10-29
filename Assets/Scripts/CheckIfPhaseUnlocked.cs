using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIfPhaseUnlocked : MonoBehaviour
{
    public bool isLocked;
    public GameObject lockedIcon;
	public GameObject openLevel;

    // Update is called once per frame
    void Update()
    {
		lockedIcon.SetActive(isLocked);
		openLevel.SetActive(!isLocked);
	}
}
