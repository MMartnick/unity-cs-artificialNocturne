using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    public void PlayAd()
    {
        UnityAdsManager.Instance.ShowRegularAd(OnAdClosed);
    }
    public void PlayRewardedAd()
    {
        UnityAdsManager.Instance.ShowRewardedAd(OnRewardedAdClosed);
    }

    private void OnAdClosed(ShowResult result)
    {

    }
    private void OnRewardedAdClosed(ShowResult result)
    {
        Debug.Log("Rewarded ad closed");
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Ad finished, reward player");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad skipped, no reward");
                break;
            case ShowResult.Failed:
                Debug.Log("Works here.");
                break;
        }
    }
}
