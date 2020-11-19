using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectorManager : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
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


	private void OnEnable()
	{
		manualMove = false;
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


        PlayerPrefs.SetInt("playerIndex", index);

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
