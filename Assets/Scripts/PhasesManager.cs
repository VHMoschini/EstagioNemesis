using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhasesManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Button> phasesButtons = new List<Button>();

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < phasesButtons.Count; i++)
        {
            if(PlayerPrefs.GetInt("LastPhaseUnlocked") > i)
            {
                phasesButtons[i].GetComponent<CheckIfPhaseUnlocked>().isLocked = false;
            }else
                phasesButtons[i].GetComponent<CheckIfPhaseUnlocked>().isLocked = true;

        }
    }
}
