﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> players = new List<GameObject>();
    int selectedPlayerIndex;
    public BulletsManager bulletsManager;
    public Camera cam;
    public BarsManager barsManager;
    [HideInInspector] public GameObject bulletInst;
    public GameObject projectile;
    public int selectedBullet = 0;
    public Material bulletMaterial;
    public int currentPlayerMaxLife;
    public int currentPlayerCurrentLife;


    void Start()
    {
        selectedPlayerIndex = PlayerPrefs.GetInt("playerIndex");
        GameObject playerInst = Instantiate(players[selectedPlayerIndex], transform.position, transform.rotation);
        playerInst.transform.SetParent(transform);
        playerInst.GetComponentInChildren<PlayerController>().bulletsManager = bulletsManager;
        playerInst.GetComponentInChildren<PlayerController>().cam = cam;
        playerInst.GetComponentInChildren<PlayerController>().projectile = projectile;
        currentPlayerMaxLife = playerInst.GetComponentInChildren<PlayerController>().characterStats.maxLife;




    }

    public void SetProjectile(GameObject _projectile)
    {
        projectile = _projectile;
    }

    public void SetProjectileIndex(int _selectedBullet)
    {
        selectedBullet = _selectedBullet;
    }

    //public void SetBulletMaterial(Material _material)
    //{
    //    bulletMaterial = _material;
    //}

    private void Update()
    {

        GameObject playerInst = GetComponentInChildren<PlayerController>().gameObject;
        playerInst.GetComponent<PlayerController>().projectile = projectile;
        playerInst.GetComponent<PlayerController>().selectedBullet = selectedBullet;
        currentPlayerCurrentLife = playerInst.GetComponentInChildren<PlayerController>().characterStats.currentLife;
        //playerInst.GetComponent<LineRenderer>().material = bulletMaterial;


    }
}