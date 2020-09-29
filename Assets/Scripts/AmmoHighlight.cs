using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AmmoHighlight : MonoBehaviour
{
	public GameObject[] Ammos;



    public void ChangePosition(int index)
	{
        GetComponent<RectTransform>().DOAnchorPosY(Ammos[index].GetComponent<RectTransform>().localPosition.y, 1f, false);
    }
}
