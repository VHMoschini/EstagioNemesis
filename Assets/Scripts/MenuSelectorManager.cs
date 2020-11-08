using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelectorManager : MonoBehaviour
{
	public List<GameObject> individualPanel = new List<GameObject>();
	int index;

	public GameObject panels;
	private bool manualMove;
	public bool stopMoving;
	private float oldMousePosition;

	public Image[] buttons;
	public Sprite[] buttonsOn;
	public Sprite[] buttonsOff;

	private void Start()
	{
		index = 1;
		stopMoving = false;
	}

	private void Update()
	{
		if (!manualMove)
		{
			panels.transform.localPosition = Vector3.Lerp(panels.transform.localPosition, new Vector3(-individualPanel[index].transform.localPosition.x, panels.transform.position.y, panels.transform.position.x), 0.2f);
		}

		for (int i = 0; i < buttons.Length; i++)
		{
			buttons[i].sprite = index == i ? buttonsOn[i] : buttonsOff[i];
		}
	}
	


	private void OnMouseDown()
	{
		oldMousePosition = Input.mousePosition.x;
		manualMove = true;
	}

	private void OnMouseDrag()
	{
		if (!stopMoving)
		{
			panels.transform.localPosition -= new Vector3(oldMousePosition - Input.mousePosition.x, 0, 0) * 2;
		}
		oldMousePosition = Input.mousePosition.x;
		manualMove = true;
	}

	private void OnMouseUp()
	{
		float lastDist = 99999;
		for (int i = 0; i < individualPanel.Count; i++)
		{
			if (Vector3.Distance(individualPanel[i].transform.position, transform.position) < lastDist)
			{
				lastDist = Vector3.Distance(individualPanel[i].transform.position, transform.position);
				Debug.Log(lastDist);
				index = i;
			}

		}
		stopMoving = false;
		manualMove = false;
	}

	public void SetIndex(int i)
	{
		index = i;
	}

	public void Stop()
	{
		stopMoving = true;
	}
}
