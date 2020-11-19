using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public List<Sprite> tutorial = new List<Sprite>();
    private int index = 0;
    public Image image;

	private GameObject tutorialObject;

    private void Awake()
    {
		tutorialObject = transform.GetChild(0).gameObject;

        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            tutorialObject.SetActive(true);
        }
        else
            tutorialObject.SetActive(false);
    }

    
    void Update()
    {
		if (index >= tutorial.Count - 1)
		{
			image.sprite = tutorial[index];
		}
		else
		{
			PlayerPrefs.SetInt("Tutorial", 1);
			tutorialObject.SetActive(false);
		}
    }


    public void Forward()
    {
        if (index < tutorial.Count-1)
            index++;
    }

    public void Backward()
    {
        if (index > 0)
            index--;
    }

    public void Skip()
    {
        tutorialObject.SetActive(false);
        PlayerPrefs.SetInt("Tutorial", 1);
        index = 0;
    }
}
