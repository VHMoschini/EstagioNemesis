using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider heroBar;
    public Slider mercenaryBar;
    public int totalEnemiesCubes;
    public int hittedEnemieCubes;
    public int totalAllyCubes;
    public int hittedAllyCubes;


    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heroBar.value = totalEnemiesCubes - (totalEnemiesCubes - hittedEnemieCubes);
    }
}
