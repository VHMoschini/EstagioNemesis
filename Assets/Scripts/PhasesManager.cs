using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhasesManager : MonoBehaviour
{
    public List<Button> phasesButtons = new List<Button>();
	public List<Image> buttonImages = new List<Image>();
	public List<Sprite> imageSprites = new List<Sprite>();

	void Update()
    {
        for (int i = 0; i < phasesButtons.Count; i++)
		{
			phasesButtons[i].GetComponent<CheckIfPhaseUnlocked>().isLocked = !(PlayerPrefs.GetInt("LastPhaseUnlocked") > i);
			buttonImages[i].sprite = (PlayerPrefs.GetInt("LastPhaseUnlocked") > i + 1) ? imageSprites[i] : buttonImages[i].sprite;
		}
	}
}
