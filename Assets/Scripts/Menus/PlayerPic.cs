using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPic : MonoBehaviour
{

	private int playerIndex;
	private Image image;
	public Sprite[] playerImages;
	
    void Start()
    {
        playerIndex = PlayerPrefs.GetInt("playerIndex");
		image = GetComponent<Image>();
		image.sprite = playerImages[playerIndex];
	}
	
}
