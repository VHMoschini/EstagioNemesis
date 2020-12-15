using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelectorManager : MonoBehaviour
{
	public List<GameObject> individualPanel = new List<GameObject>();
	int index;
	public static MenuSelectorManager instance;

	public GameObject panels;
	private bool manualMove;
	public bool stopMoving;
	private float oldMousePosition;

	public Image[] buttons;
	public Sprite[] buttonsOn;
	public Sprite[] buttonsOff;

	private void Awake()
	{
		if(instance == null)
		instance = this;
	}
	private void Start()
	{
		index = 0;
		stopMoving = false;
	}

	private void Update()
	{
		if (!manualMove)
		{
			panels.transform.localPosition = Vector3.Lerp(panels.transform.localPosition, new Vector3(-individualPanel[index].transform.localPosition.x, panels.transform.localPosition.y, panels.transform.localPosition.z), 0.2f);
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
			panels.transform.localPosition -= new Vector3(oldMousePosition - Input.mousePosition.x, 0, 0) * 1.3f;
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
