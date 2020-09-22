using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider heroBar;
    public Slider mercenaryBar;
    public int hittedEnemieCubes;
    public int hittedAllyCubes;
    int fase;
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
                heroBar.value = hittedEnemieCubes * 0.4975f;
                mercenaryBar.value = hittedAllyCubes * 2.56f;
                break;
            case 4:
                heroBar.value = hittedEnemieCubes * 0.3891f;
                mercenaryBar.value = hittedAllyCubes * 3.03f;
                break;
            case 5:
                heroBar.value = hittedEnemieCubes * 0.4237f;
                mercenaryBar.value = hittedAllyCubes * 3.22f;
                break;
        }




    }
}
