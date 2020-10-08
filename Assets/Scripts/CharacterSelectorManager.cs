using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectorManager : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
    int index;
    public GameObject rightButton;
    public GameObject leftButton;
	
	public GameObject charactersGeneral;
	private bool manualMove;
	private float oldMousePosition;

    void Start()
    {/*
        for (int i = 0; i < characters.Count; i++)
        {
           if(i == 0)
            {
                characters[i].gameObject.SetActive(true);
            }else
                characters[i].gameObject.SetActive(false);

        }*/
    }

    // Update is called once per frame
    void Update()
    {
		if (!manualMove)
		{
			charactersGeneral.transform.localPosition = Vector3.Lerp(charactersGeneral.transform.localPosition, -characters[index].transform.localPosition, 0.2f);
		}/*
        for (int i = 0; i < characters.Count; i++)
        {
            if (i == index)
            {
                characters[i].gameObject.SetActive(true);
            }
            else
                characters[i].gameObject.SetActive(false);
        }*/

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


        PlayerPrefs.SetInt("playerIndex", index);

    }

    private void OnMouseDown()
	{
		oldMousePosition = Input.mousePosition.x;
		manualMove = true;
	}

	private void OnMouseDrag()
	{
		charactersGeneral.transform.localPosition -= new Vector3(oldMousePosition - Input.mousePosition.x, 0, 0);
		oldMousePosition = Input.mousePosition.x;
	}

	private void OnMouseUp()
	{
		float lastDist = 99999;
		for (int i = 0; i < characters.Count; i++)
		{
			if (Vector3.Distance(characters[i].transform.position, transform.position) < lastDist)
			{
				lastDist = Vector3.Distance(characters[i].transform.position, transform.position);
				Debug.Log(lastDist);
				index = i;
			}

		}
		manualMove = false;
	}

	public void RightArrow()
    {
        index++;
    }

    public void LeftArrow()
    {
        index--;
    }
}
