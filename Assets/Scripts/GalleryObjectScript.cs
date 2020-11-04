using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryObjectScript : MonoBehaviour
{
    [HideInInspector] public GameObject imageExpand;

    private void Start()
    {
        imageExpand = GetComponentInParent<GalleryManager>().imageExpand;
    }


    public void Expand()
    {
        Debug.Log("ai");
        imageExpand.SetActive(true);
        imageExpand.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
    }
}
