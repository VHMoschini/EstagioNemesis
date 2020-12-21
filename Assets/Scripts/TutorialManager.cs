using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public List<Sprite> tutorial = new List<Sprite>();
    private int index = 0;
    public Image image;
	public GameObject voltarButton;

	private GameObject tutorialObject;

    private void Awake()
    {
		tutorialObject = transform.GetChild(0).gameObject;
		
		//if (SceneManager.GetActiveScene().buildIndex == 2)
		//{
		//    tutorialObject.SetActive(true);
		//}
		//else
		//    tutorialObject.SetActive(false);
	}

	private void Start()
	{
		Time.timeScale = 0;
	}

	void Update()
    {
		//if (index >= tutorial.Count - 1)
		//{
			image.sprite = tutorial[index];
		
		voltarButton.SetActive(index > 0);

		if(index < 2) Time.timeScale = 0;

		//}
		//else
		//{
		//    //PlayerPrefs.SetInt("Tutorial", 1);
		//    tutorialObject.SetActive(false);
		//}
	}


    public void Forward()
    {
		if (index < tutorial.Count - 1)
			index++;
		else
			Skip();
    }

    public void Backward()
    {
        if (index > 0)
            index--;
    }

    public void Skip()
    {
        tutorialObject.SetActive(false);
        //PlayerPrefs.SetInt("Tutorial", 1);
        //index = 0;
		Time.timeScale = 1;
	}

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
