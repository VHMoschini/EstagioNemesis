using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectorManager : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
    int index;
    public GameObject rightButton;
    public GameObject leftButton;

    void Start()
    {
        for (int i = 0; i < characters.Count; i++)
        {
           if(i == 0)
            {
                characters[i].gameObject.SetActive(true);
            }else
                characters[i].gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (i == index)
            {
                characters[i].gameObject.SetActive(true);
            }
            else
                characters[i].gameObject.SetActive(false);
        }

        if(index == characters.Count-1)
        {
            rightButton.SetActive(false);
        }else
            rightButton.SetActive(true);


        if(index == 0)
        {
            leftButton.SetActive(false);
        }
        else
            leftButton.SetActive(true);
    }

    public void RightArrow()
    {
        index++;
    }

    public void LeftArrow()
    {
        index--;
    }


    public void Play()
    {
        PlayerPrefs.SetInt("playerIndex", index);
    }
}
