using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> projectiles = new List<GameObject>();
    public GameObject defeatPanel;
    private bool dead;
    int selectedPlayerIndex;
    public BulletsManager bulletsManager;
    public Camera cam;
    public BarsManager barsManager;
    [HideInInspector] public GameObject bulletInst;
    [HideInInspector] public GameObject projectile;
    [HideInInspector] public int selectedBullet = 0;
    [HideInInspector] public int currentPlayerMaxLife;
    [HideInInspector] public int currentPlayerCurrentLife;
    public Color[] colors;


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


    public void SetProjectileIndex()
    {
        if (selectedBullet < bulletsManager.bullets.Length-1)
            selectedBullet++;
        else
            selectedBullet = 0;
    }


    public void SetProjectile()
    {
        projectile = projectiles[selectedBullet];
    }


    private void Update()
    {
        SetProjectile();
        GameObject playerInst = GetComponentInChildren<PlayerController>().gameObject;
        playerInst.GetComponent<PlayerController>().projectile = projectile;
        playerInst.GetComponent<PlayerController>().selectedBullet = selectedBullet;
        currentPlayerCurrentLife = playerInst.GetComponentInChildren<PlayerController>().characterStats.currentLife;
        playerInst.GetComponent<LineRenderer>().startColor = colors[selectedBullet];


        if (currentPlayerCurrentLife == 0 && !dead)
        {
            dead = true;
            Die();
        }
    }

    public void Die()
    {
        defeatPanel.SetActive(true);
        Time.timeScale = 0;
        dead = false;

    }
}
