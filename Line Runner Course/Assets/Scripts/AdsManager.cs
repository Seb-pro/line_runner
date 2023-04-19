using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public static AdsManager instance;
    private GameManager gameManager;
    string gameID = "5252500";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Advertisement.AddListener(this);
        Advertisement.Initialize(gameID);
        }
    }

    public void ShowAds(GameManager gameManager)
    {
       this.gameManager = gameManager;
       Advertisement.Show("Rewarded_Android");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Unity Ads Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ads Started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                  gameManager.ReloadLevel();
                break;
            case ShowResult.Skipped:
                // Ad was skipped
                break;
            case ShowResult.Failed:
                Debug.LogWarning("Ad Failed");
                break;
        }
    }
}
