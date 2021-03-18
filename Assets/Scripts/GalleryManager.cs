using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] images;
    public GameObject imageExpand;
    private List<GameObject> imagesList = new List<GameObject>();
    public float imageSizex;
    public float imageSizey;
    private RectTransform rectTransform;
    public float spaceBetweenImagesx;
    public float spaceBetweenImagesy;
    public float maxImagesPerLine;
    public Vector2 firstImagePos;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        CreateImages();
    }

    public void CreateImages()
    {
        for (int i = 0; i < images.Length; i++)
        {
            GameObject imageInst = Instantiate(images[i], rectTransform.position, rectTransform.rotation);
            imageInst.GetComponent<RectTransform>().SetParent(rectTransform);
            imageInst.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
            imageInst.GetComponent<RectTransform>().sizeDelta = new Vector2(imageSizex, imageSizey);
            imagesList.Add(imageInst);
        }
        CreateGrid();
    }

    public void CreateGrid()
    {
        int imagesInLine = 0;
        int columns = 0;

        for (int i = 0; i < imagesList.Count; i++)
        {
            imagesList[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(
                firstImagePos.x + spaceBetweenImagesx * imagesInLine,
                firstImagePos.y - spaceBetweenImagesy * columns,
                0);
            imagesInLine++;
            if (imagesInLine == 4)
            {
                columns++;
                imagesInLine = 0;
            }
        }
    }
}
