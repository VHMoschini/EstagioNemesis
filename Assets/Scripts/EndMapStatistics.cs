using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMapStatistics : MonoBehaviour
{
    public BarsManager barsManager;
    public TextMeshProUGUI panelTXT;

    private void OnEnable()
    {
        SetVictoryPanelStatistics();
    }


    public void SetVictoryPanelStatistics()
    {
        panelTXT.text = "Blocos Inimigos Destruídos: " + string.Format("{0:#.00} %", barsManager.hittedEnemieCubes * barsManager.enemyCubeProportion[barsManager.fase-2] * 100) + "\n Blocos Aliados Destruídos: " + string.Format("{0:#.00} %" , barsManager.hittedAllyCubes * barsManager.allyCubeProportion[barsManager.fase-2] * 100);
    }

}
