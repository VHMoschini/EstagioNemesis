using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BulletsManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Bullet[] bullets;

    void Start()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].currentBulletNum = bullets[i].maxBulletNum;
        }
    }

    private void Update()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].bulletNumText.text = bullets[i].currentBulletNum.ToString();
        }
    }

}


[Serializable]
public class Bullet
{
    public int maxBulletNum;
    public int currentBulletNum;
    public Text bulletNumText;

}
