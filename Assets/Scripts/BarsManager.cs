using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarsManager : MonoBehaviour
{
    //barras de heroi/mercenario vars
    [HideInInspector] public int hittedEnemieCubes;
    [HideInInspector] public int hittedAllyCubes;
    int fase;
    public Image heroSnakeBar;
    public Image mercenarySnakeBar;
    //turret vars
    public GameObject turret;
    public GameObject player;
    public List<Transform> turretPlaces = new List<Transform>();
    private bool hasSpawned;
    //barra de vida
    public Slider lifeBar;
    public Text textLifeBar;
    public Text nextPhaseUnlocked;
    private bool sawText;
    void Start()
    {
        fase = SceneManager.GetActiveScene().buildIndex;
    }
    void Update()
    {
        lifeBar.maxValue = player.GetComponent<PlayerCharacterManager>().currentPlayerMaxLife;
        lifeBar.value = player.GetComponent<PlayerCharacterManager>().currentPlayerCurrentLife;
        textLifeBar.text = lifeBar.value.ToString();

        switch (fase)
        {
            case 3:
                heroSnakeBar.fillAmount = hittedEnemieCubes * (0.4975f / 100);
                mercenarySnakeBar.fillAmount = hittedAllyCubes * (2.56f / 100);
                if (heroSnakeBar.fillAmount > 0.3 && !hasSpawned)
                {
                    CreateTurret();
                    hasSpawned = true;
                }else if(heroSnakeBar.fillAmount >= 0.6 && !sawText)
                {
                    StartCoroutine(ShowText());
                    PlayerPrefs.SetInt("LastPhaseUnlocked", 2);
                    sawText = true;
                }
                break;
            case 4:
                heroSnakeBar.fillAmount = hittedEnemieCubes * (0.3891f / 100);
                mercenarySnakeBar.fillAmount = hittedAllyCubes * (3.03f / 100);
                if (heroSnakeBar.fillAmount > 0.35 && !hasSpawned)
                {
                    CreateTurret();
                    hasSpawned = true;
                }
                else if (heroSnakeBar.fillAmount >= 0.7 && !sawText)
                {
                    StartCoroutine(ShowText());
                    PlayerPrefs.SetInt("LastPhaseUnlocked", 3);
                    sawText = true;

                }
                break;
            case 5:
                heroSnakeBar.fillAmount = hittedEnemieCubes * (0.4237f / 100);
                mercenarySnakeBar.fillAmount = hittedAllyCubes * (3.22f / 100);
                if (heroSnakeBar.fillAmount > 0.35 && !hasSpawned)
                {
                    CreateTurret();
                    hasSpawned = true;
                }
                else if (heroSnakeBar.fillAmount >= 0.7 && !sawText)
                {
                    StartCoroutine(ShowText());
                    sawText = true;
                }
                break;
        }
    }


    void CreateTurret()
    {
        for (int i = 0; i < turretPlaces.Count; i++)
        {
            GameObject turretInst = Instantiate(turret, turretPlaces[i].position, turretPlaces[i].rotation);
            turretInst.GetComponentInChildren<TurretScript>().player = player.transform;

        }
    }


    IEnumerator ShowText()
    {
        nextPhaseUnlocked.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        nextPhaseUnlocked.gameObject.SetActive(false);

    }
}
