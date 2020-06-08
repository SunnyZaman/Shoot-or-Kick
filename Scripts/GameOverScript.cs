using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class GameOverScript : MonoBehaviour {
	private BannerView bannerView;
	private InterstitialAd interstitial;

	void Awake(){
		Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
		#if UNITY_EDITOR
		Debug.logger.logEnabled = false;
		#else
		Debug.logger.logEnabled = false;
		#endif
	}

	void Start () {
		this.RequestBanner();
		this.RequestInterstitial ();
	}
	public void RestartLevel(){
		this.bannerView.Destroy();
		int rand;
		rand = UnityEngine.Random.Range (1,12); //9 numbers 1,2,3,4,5,6,7,8,9,10,11
		if (rand == 2 || rand == 4 || rand == 6 || rand == 9) {
			this.ShowInterstitial ();
		}
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void MainMenu(){
		this.bannerView.Destroy();
		SceneManager.LoadScene ("Menu Scene");
	}

	// Returns an ad request with custom ad targeting.
	private AdRequest CreateAdRequest()
	{
		return new AdRequest.Builder().Build();
	}

	private void RequestBanner()
	{

		string adUnitId2 = "banner-ad-id"; 

		// Clean up banner ad before creating a new one.
		if (this.bannerView != null)
		{
		this.bannerView.Destroy();
		}

		// Create a 320x50 banner at the top of the screen.
		this.bannerView = new BannerView(adUnitId2, AdSize.SmartBanner, AdPosition.Bottom);

		// Register for ad events.
		this.bannerView.OnAdLoaded += this.HandleAdLoaded;
		this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
		this.bannerView.OnAdOpening += this.HandleAdOpened;
		this.bannerView.OnAdClosed += this.HandleAdClosed;
		this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;

		// Load a banner ad.
		this.bannerView.LoadAd(this.CreateAdRequest());
		}

		#region Banner callback handlers

		public void HandleAdLoaded(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleAdLoaded event received");
		}

		public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
		}

		public void HandleAdOpened(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleAdOpened event received");
		}

		public void HandleAdClosed(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleAdClosed event received");
		}

		public void HandleAdLeftApplication(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleAdLeftApplication event received");
		}

		#endregion



		private void RequestInterstitial()
		{

		string adUnitId1 = "interstitial-ad-id";

		// Clean up interstitial ad before creating a new one.
		if (this.interstitial != null)
		{
		this.interstitial.Destroy();
		}

		// Create an interstitial.
		this.interstitial = new InterstitialAd(adUnitId1);

		// Register for ad events.
		this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
		this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
		this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
		this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
		this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;

		// Load an interstitial ad.
		this.interstitial.LoadAd(this.CreateAdRequest());
		}

		private void ShowInterstitial()
		{
		if (this.interstitial.IsLoaded())
		{
		this.interstitial.Show();
		}
		else
		{
		MonoBehaviour.print("Interstitial is not ready yet");
		}
		}

		#region Interstitial callback handlers

		public void HandleInterstitialLoaded(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleInterstitialLoaded event received");
		}

		public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		MonoBehaviour.print(
		"HandleInterstitialFailedToLoad event received with message: " + args.Message);
		}

		public void HandleInterstitialOpened(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleInterstitialOpened event received");
		}

		public void HandleInterstitialClosed(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleInterstitialClosed event received");
		}

		public void HandleInterstitialLeftApplication(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleInterstitialLeftApplication event received");
		}

		#endregion
}
