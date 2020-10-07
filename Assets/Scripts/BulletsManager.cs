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
    private int index;
    public PlayerCharacterManager playerCharacterManager;

    void Start()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].currentBulletNum = bullets[i].maxBulletNum;
        }
    }

    private void Update()
    {
        bulletText.text = bullets[playerCharacterManager.selectedBullet].currentBulletNum + "/" + bullets[playerCharacterManager.selectedBullet].maxBulletNum;
    }

}


[Serializable]
public class Bullet
{
    public int maxBulletNum;
    public int currentBulletNum;

}
