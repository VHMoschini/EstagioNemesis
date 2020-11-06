using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryObjectScript : MonoBehaviour
{
    [HideInInspector] public GameObject imageExpand;
    private bool isUnlocked;
    public Sprite lockedImage;
    public Sprite unlockedImage;
    public int cardId;



    private void Start()
    {
        imageExpand = GetComponentInParent<GalleryManager>().imageExpand;
        if(PlayerPrefs.GetInt("cards") >= cardId)
        {
            isUnlocked = true;
            GetComponent<Image>().sprite = unlockedImage;
        }else
            GetComponent<Image>().sprite = lockedImage;


    }


    public void Expand()
    {
        if (isUnlocked)
        {
            imageExpand.SetActive(true);
            imageExpand.GetComponent<Image>().sprite = unlockedImage;
        }
    }
}
