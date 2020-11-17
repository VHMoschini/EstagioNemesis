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
        panelTXT.text = "Blocos Inimigos Destruídos: " + barsManager.hittedEnemieCubes + "\n Blocos Aliados Destruídos: " + barsManager.hittedAllyCubes;
    }

}
