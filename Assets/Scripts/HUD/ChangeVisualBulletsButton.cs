﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVisualBulletsButton : MonoBehaviour
{
    public List<Sprite> projectilesImage = new List<Sprite>();
    [HideInInspector]public int projectileIndex;
	public PlayerCharacterManager characterManager;


    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite = projectilesImage[projectileIndex];        
    }

    public void SetProjectileIndex()
    {
		if (PlayerController.isAiming) return;
		characterManager.SetProjectileIndex();
        if (projectileIndex < projectilesImage.Count-1)
            projectileIndex++;
        else
            projectileIndex = 0;
    }
}
