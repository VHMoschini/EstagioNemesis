using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarsManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int hittedEnemieCubes;
    public int hittedAllyCubes;
    int fase;
    public Image heroSnakeBar;
    public Image mercenarySnakeBar;
    void Start()
    {
         fase = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        switch (fase)
        {
            case 3:
                heroSnakeBar.DOFillAmount(hittedEnemieCubes * (0.4975f / 100), 1f);
                mercenarySnakeBar.DOFillAmount(hittedAllyCubes * (2.56f / 100), 1f);
                break;
            case 4:
                heroSnakeBar.DOFillAmount(hittedEnemieCubes * (0.3891f / 100), 1f);
                mercenarySnakeBar.DOFillAmount(hittedAllyCubes * (3.03f / 100), 1f);
                break;
            case 5:
                heroSnakeBar.DOFillAmount(hittedEnemieCubes * (0.4237f / 100), 1f);
                mercenarySnakeBar.DOFillAmount(hittedAllyCubes * (3.22f / 100), 1f);
                break;
        }




    }
}
