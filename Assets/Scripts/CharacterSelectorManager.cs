using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectorManager : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
	private List<Image> characterImages = new List<Image>();
	public List<Sprite> characterSprites = new List<Sprite>();
    int index;
    public Image rightButton;
    public Image leftButton;
	public Sprite rightArrow;
	public Sprite rightArrowFalse;
	public Sprite leftArrow;
	public Sprite leftArrowFalse;

	public GameObject charactersGeneral;
	private bool manualMove;
	private float oldMousePosition;

	public GameObject selectedCharacterPortrait;
	private RectTransform scRect;
	private Image scImage;

	public Sprite[] characterPortraits;

	private void OnEnable()
	{
		manualMove = false;
		scImage = selectedCharacterPortrait.GetComponent<Image>();
		scRect = selectedCharacterPortrait.GetComponent<RectTransform>();
		index = PlayerPrefs.GetInt("playerIndex", 0);
		for (int i = 0; i < characters.Count; i++)
		{
			characterImages.Add(characters[i].transform.GetChild(0).GetComponent<Image>());
			if (PlayerPrefs.GetInt("PersonagensLiberados", 0) >= i)
			{
				characterImages[i].sprite = characterSprites[i];
			}
		}
	}

	
    void Update()
    {
		if (!manualMove)
		{
			charactersGeneral.transform.localPosition = Vector3.Lerp(charactersGeneral.transform.localPosition, -characters[index].transform.localPosition, 0.2f);
		}

        if (index == characters.Count - 1)
        {
            rightButton.sprite = rightArrowFalse;
            rightButton.GetComponent<Button>().enabled = false; //p n tocar som
        }
        else
        {
            rightButton.sprite = rightArrow;
            rightButton.GetComponent<Button>().enabled = true;
        }

        if (index == 0)
        {
            leftButton.sprite = leftArrowFalse;
            leftButton.GetComponent<Button>().enabled = false;
        }
        else
        {
            leftButton.sprite = leftArrow;
            leftButton.GetComponent<Button>().enabled = true;
        }


		if (PlayerPrefs.GetInt("PersonagensLiberados", 0) >= index)
		{
			PlayerPrefs.SetInt("playerIndex", index);
			scImage.sprite = characterPortraits[index];
		}
	}

	private void LateUpdate()
	{
		scRect.anchoredPosition = new Vector2(Mathf.Clamp(-transform.position.x * 10 + 47, 47, 1080 + 70), scRect.anchoredPosition.y);
	}

	public void RightArrow()
    {
		if(index < characters.Count - 1)
        index++;
    }

    public void LeftArrow()
    {
		if(index > 0)
        index--;
    }
}
