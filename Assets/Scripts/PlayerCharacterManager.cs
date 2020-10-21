using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> projectiles = new List<GameObject>();
    public GameObject defeatPanel;
	public GameObject VictoryPanel;
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

	
	private GameObject playerInst;
	private PlayerController playerController;
	private LineRenderer lineRenderer;



	void Start()
    {
        selectedPlayerIndex = PlayerPrefs.GetInt("playerIndex");
        playerInst = Instantiate(players[selectedPlayerIndex], transform.position, transform.rotation);
        playerInst.transform.SetParent(transform);
		playerController = playerInst.GetComponentInChildren<PlayerController>();
		lineRenderer = playerInst.GetComponentInChildren<LineRenderer>();
        playerController.bulletsManager = bulletsManager;
		playerController.cam = cam;
		playerController.projectile = projectile;
        currentPlayerMaxLife = playerController.characterStats.maxLife;

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
		playerController.projectile = projectile;
		playerController.selectedBullet = selectedBullet;
        currentPlayerCurrentLife = playerController.characterStats.currentLife;
        lineRenderer.startColor = colors[selectedBullet];


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

	public IEnumerator NoMoreBullets()
	{
		yield return new WaitForSeconds(5);
		if (barsManager.sawText)
		{
			VictoryPanel.SetActive(true);
		}
		else
		{
			Die();
		}
		Time.timeScale = 0;
	}
}
