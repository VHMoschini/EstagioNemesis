using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIfPhaseUnlocked : MonoBehaviour
{
    public bool isLocked;
    public GameObject lockedIcon;

    // Update is called once per frame
    void Update()
    {
        if (isLocked == true)
        {
            lockedIcon.SetActive(true);
        }
        else
            lockedIcon.SetActive(false);
    }
}
