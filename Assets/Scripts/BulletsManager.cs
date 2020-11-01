using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class BulletsManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Bullet[] bullets;
    public TMP_Text bulletText;
	public Image zeroBulletHighlight;
    private int index;
    public PlayerCharacterManager playerCharacterManager;

    void Start()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].currentBulletNum = bullets[i].maxBulletNum;
        }
		zeroBulletHighlight.color = Color.white;
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
		if (emptyBullets == bullets.Length)
		{
			playerCharacterManager.StartCoroutine("NoMoreBullets");

		}
	}

}


[Serializable]
public class Bullet
{
    public int maxBulletNum;
    public int currentBulletNum;

}
