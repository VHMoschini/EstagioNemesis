using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider heroBar;
    public Slider mercenaryBar;
    public int hittedEnemieCubes;
    public int hittedAllyCubes;


    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heroBar.value = hittedEnemieCubes * 0.4975f;
        mercenaryBar.value = hittedAllyCubes * 2.56f;

    }
}
