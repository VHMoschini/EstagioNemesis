using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class BulletsManager : MonoBehaviour
{
	public static BulletsManager instance;

    public Bullet[] bullets;
    public TMP_Text bulletText;
	public Image zeroBulletHighlight;
    private int index;
    public PlayerCharacterManager playerCharacterManager;

	private bool coroutineSent;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this);
		}
	}


	void Start()
    {
		ResetBullets();
    }

    private void Update()
    {
        bulletText.text = bullets[playerCharacterManager.selectedBullet].currentBulletNum + "/" + bullets[playerCharacterManager.selectedBullet].maxBulletNum;
		zeroBulletHighlight.color = bullets[playerCharacterManager.selectedBullet].currentBulletNum == 0 ? Color.grey : Color.white;


		int emptyBullets = 0;
		for (int i = 0; i < bullets.Length; i++)
		{
			if (bullets[i].currentBulletNum == 0)
			{
				emptyBullets++;
			}
		}
		if (emptyBullets == bullets.Length && !coroutineSent)
		{
			coroutineSent = true;
			playerCharacterManager.StartCoroutine("NoMoreBullets");

		}
	}

	public void ResetBullets()
	{
		for (int i = 0; i < bullets.Length; i++)
		{
			bullets[i].currentBulletNum = bullets[i].maxBulletNum;
		}
		zeroBulletHighlight.color = Color.white;
		coroutineSent = false;
	}

}


[Serializable]
public class Bullet
{
    public int maxBulletNum;
    public int currentBulletNum;

}
