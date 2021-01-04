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
	[HideInInspector] public float[] enemyCubeProportion = new float[3];
	[HideInInspector] public float[] allyCubeProportion = new float[3];
	[HideInInspector] public int fase;
    public Image heroSnakeBar;
    public Image mercenarySnakeBar;
    //turret vars
    public GameObject turret;
    public GameObject player;
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

		enemyCubeProportion[0] = (0.4975f / 100);
		enemyCubeProportion[1] = (0.3891f / 100);
		enemyCubeProportion[2] = (0.4237f / 100);

		allyCubeProportion[0] = (2.56f / 100);
		allyCubeProportion[1] = (3.03f / 100);
		allyCubeProportion[2] = (3.22f / 100);

	}
    void Update()
    {
        lifeBarFill.fillAmount = ((player.GetComponent<PlayerCharacterManager>().currentPlayerCurrentLife*100f)/ player.GetComponent<PlayerCharacterManager>().currentPlayerMaxLife)/100f;
        textLifeBar.text = player.GetComponent<PlayerCharacterManager>().currentPlayerCurrentLife.ToString();
        switch (fase)
        {
            case 2:
                heroSnakeBar.fillAmount = hittedEnemieCubes * enemyCubeProportion[0];
                mercenarySnakeBar.fillAmount = hittedAllyCubes * allyCubeProportion[0];
                if (heroSnakeBar.fillAmount > 0.3 && !hasSpawned)
                {
                    CreateTurret();
                    hasSpawned = true;
                }else if(heroSnakeBar.fillAmount >= 0.6 && !sawText)
                {
                    StartCoroutine(ShowText());
                    PlayerPrefs.SetInt("LastPhaseUnlocked", 2);
                    PlayerPrefs.SetInt("cards", 1);
                    goToNextPhaseButton.SetActive(true);
                    sawText = true;
                }
                break;
            case 3:
				heroSnakeBar.fillAmount = hittedEnemieCubes * enemyCubeProportion[1];
				mercenarySnakeBar.fillAmount = hittedAllyCubes * allyCubeProportion[1];
				if (heroSnakeBar.fillAmount > 0.35 && !hasSpawned)
                {
                    CreateTurret();
                    hasSpawned = true;
                }
                else if (heroSnakeBar.fillAmount >= 0.7 && !sawText)
                {
                    StartCoroutine(ShowText());
                    PlayerPrefs.SetInt("LastPhaseUnlocked", 3);
                    PlayerPrefs.SetInt("cards", 2);
                    goToNextPhaseButton.SetActive(true);
                    sawText = true;

                }
                break;
            case 4:
				heroSnakeBar.fillAmount = hittedEnemieCubes * enemyCubeProportion[2];
				mercenarySnakeBar.fillAmount = hittedAllyCubes * allyCubeProportion[2];
				if (heroSnakeBar.fillAmount > 0.35 && !hasSpawned)
                {
                    CreateTurret();
                    hasSpawned = true;
                }
                else if (heroSnakeBar.fillAmount >= 0.7 && !sawText)
                {
                    StartCoroutine(ShowText());
					PlayerPrefs.SetInt("LastPhaseUnlocked", 4);
					PlayerPrefs.SetInt("cards", 3);
					sawText = true;
                }
                break;
        }

		if (heroSnakeBar.fillAmount > mercenarySnakeBar.fillAmount)
		{
			heroSnakeBar.transform.SetSiblingIndex(3);
		}
		else
		{
			mercenarySnakeBar.transform.SetSiblingIndex(3);
		}
    }


    void CreateTurret()
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
        nextPhaseUnlocked.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        nextPhaseUnlocked.gameObject.SetActive(false);

    }
}
