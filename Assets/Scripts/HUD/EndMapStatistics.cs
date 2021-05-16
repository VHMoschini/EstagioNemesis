using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
		string enemyHit = string.Format("{0:#.00} %", barsManager.hittedEnemieCubes * barsManager.enemyCubeProportion * 100);
		string allyHit = string.Format("{0:#.00} %", barsManager.hittedAllyCubes * barsManager.allyCubeProportion * 100);

		panelTXT.text = "Blocos Inimigos Destruídos: " + enemyHit + "\n Blocos Aliados Destruídos: " + allyHit;
		#region Firebase
		Firebase.Analytics.FirebaseAnalytics.LogEvent(
Firebase.Analytics.FirebaseAnalytics.EventPostScore,
new Firebase.Analytics.Parameter[] {
	new Firebase.Analytics.Parameter(
	  Firebase.Analytics.FirebaseAnalytics.ParameterCharacter, "N/A"),
	new Firebase.Analytics.Parameter(
	  Firebase.Analytics.FirebaseAnalytics.ParameterLevel, SceneManager.GetActiveScene().name),
	new Firebase.Analytics.Parameter(
	  Firebase.Analytics.FirebaseAnalytics.ParameterScore, panelTXT.text),
}
);
		#endregion
	}

}
