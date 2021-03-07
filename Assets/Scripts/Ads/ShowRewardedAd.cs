using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRewardedAd : MonoBehaviour
{
	public GameObject ShowAdButton;

	public void ShowAd()
	{
		RewardedAdManager.instance.UserChoseToWatchAd();
	}
	private void Awake()
	{
		ShowAdButton.SetActive(RewardedAdManager.instance.isLoaded);
	}
	private void Update()
	{
		ShowAdButton.SetActive(RewardedAdManager.instance.isLoaded);
	}
	
}
