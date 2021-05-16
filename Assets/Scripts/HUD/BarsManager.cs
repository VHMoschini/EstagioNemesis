using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BarsManager : MonoBehaviour
{
    //barras de heroi/mercenario vars
    [HideInInspector] public int hittedEnemieCubes;
    [HideInInspector] public int hittedAllyCubes;
    public float enemyCubeProportion;
    public float allyCubeProportion;
    [HideInInspector] public int fase;
    public Image heroSnakeBar;
    public Image mercenarySnakeBar;
    //turret vars
    public GameObject turret;
    public GameObject player;
    private PlayerCharacterManager characterManager;
    public List<Transform> turretPlaces = new List<Transform>();
    private bool hasSpawned;
    //barra de vida
    public Image lifeBarFill;
    public TMP_Text textLifeBar;
    public TMP_Text nextPhaseUnlocked;
    [HideInInspector] public bool sawText;
    public GameObject goToNextPhaseButton;
    void Start()
    {
        fase = SceneManager.GetActiveScene().buildIndex;


        characterManager = PlayerCharacterManager.instance;

    }
    void Update()
    {
        lifeBarFill.fillAmount = ((characterManager.currentPlayerCurrentLife * 100f) / characterManager.currentPlayerMaxLife) / 100f;
        textLifeBar.text = characterManager.currentPlayerCurrentLife.ToString();
        heroSnakeBar.fillAmount = hittedEnemieCubes * enemyCubeProportion;
        mercenarySnakeBar.fillAmount = hittedAllyCubes * allyCubeProportion;


        if (heroSnakeBar.fillAmount > 0.3 && !hasSpawned)
        {
            CreateTurret();
            hasSpawned = true;
        }
        else if (heroSnakeBar.fillAmount >= 0.6 && !sawText)
        {
            StartCoroutine(ShowText());
            goToNextPhaseButton.SetActive(true);
            sawText = true;
			
		}
		//Libera as cartas
		if (fase == 4 )
        {
            PlayerPrefs.SetInt("cards", 1);
            PlayerPrefs.SetInt("LastPhaseUnlocked", fase);

        }
        else if(fase == 7 )
        {
            PlayerPrefs.SetInt("cards", 2);
            PlayerPrefs.SetInt("LastPhaseUnlocked", fase);

        }
        else if (fase == 10)
        {
            PlayerPrefs.SetInt("cards", 3);
            PlayerPrefs.SetInt("LastPhaseUnlocked", fase);

        }

        if (heroSnakeBar.fillAmount > mercenarySnakeBar.fillAmount)
        {
            heroSnakeBar.transform.SetSiblingIndex(3);
        }
        else
        {
            mercenarySnakeBar.transform.SetSiblingIndex(3);
        }

        if (hittedEnemieCubes > 0 || hittedAllyCubes > 0)
        {
            HominhoWalk.isAfraid = true;
        }
    }


    private void CreateTurret()
    {
        for (int i = 0; i < turretPlaces.Count; i++)
        {
            GameObject turretInst = Instantiate(turret, turretPlaces[i].position, turretPlaces[i].rotation);
            turretInst.GetComponentInChildren<TurretScript>().player = player.transform;
            if (GetComponent<AudioSource>())
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }


    IEnumerator ShowText()
    {
        AdManager.instance.ShowInterstitial();
        nextPhaseUnlocked.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        nextPhaseUnlocked.gameObject.SetActive(false);

    }
}
