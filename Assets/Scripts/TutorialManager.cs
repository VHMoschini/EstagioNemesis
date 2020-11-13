using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public List<Sprite> tutorial = new List<Sprite>();
    private int index = 0;
    public Image image;

    private void Awake()
    {
        //if (PlayerPrefs.GetInt("Tutorial") == 0)
        //{
        //    gameObject.SetActive(true);
        //}
        //else
        //    gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = tutorial[index];
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
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("Tutorial", 1);
        index = 0;
    }
}
