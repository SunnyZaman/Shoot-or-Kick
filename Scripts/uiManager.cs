using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DigitalRuby.SoundManagerNamespace; 

public class uiManager : MonoBehaviour {
	public string ANDROID_RATE_URL = "http://play.google.com/store/apps/details?id=com.PSZ.ShootorKick";

	public Transform MuteOn;
	public Transform SoundOn;

	public Text HighScoreG1;
	public Text HighScoreG2;

	public AudioSource[] SoundAudioSources;
	public AudioSource[] MusicAudioSources;

	public Transform AlertBasketballTab1;
	public Transform AlertSoccerTab1;
	public Transform AlertBasketballTab2;
	public Transform AlertSoccerTab2;

	public Transform AlertImage;
	public Transform AlertBasketball2;
	public Transform AlertBasketball3;
	public Transform AlertSoccer2;
	public Transform AlertSoccer3;

	public Transform Menu;
	public Transform GameModes;
	public Transform LoadingScreen;
	public Transform LoadingScreen2;
	public Transform Customization1;
	public Transform Customization2;

	public Transform PickedBorderBasketball1;
	public Transform PickedBorderBasketball2;
	public Transform PickedBorderBasketball3;

	public Transform UnlockedBasketball2;
	public Transform LockedBasketball2;
	public Transform UnlockedBasketball3;
	public Transform LockedBasketball3;

	public Transform PickedBorderSoccer1;
	public Transform PickedBorderSoccer2;
	public Transform PickedBorderSoccer3;

	public Transform UnlockedSoccer2;
	public Transform LockedSoccer2;
	public Transform UnlockedSoccer3;
	public Transform LockedSoccer3;

	public Text ballsLeftsBB3;
	public Text ballsLeftsSB3;

	private void PlaySound(int index)
	{

		SoundAudioSources[index].PlayOneShotSoundManaged(SoundAudioSources[index].clip);
	}

	private void PlayOneTimeMusic(int index){
		MusicAudioSources[index].PlayOneShotSoundManaged(MusicAudioSources[index].clip);
	}

	private void PlayMusic(int index)
	{
		MusicAudioSources[index].PlayLoopingMusicManaged(1.0f, 1.0f, true);
	}
	void Awake(){
		Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
	}

	void Start () {

		if (PlayerPrefs.HasKey ("Audio")) {
			if (PlayerPrefs.GetInt ("Audio") == 0) {
				AudioListener.volume = 0;
				MuteOn.gameObject.SetActive (true);
				SoundOn.gameObject.SetActive(false);
			} else if (PlayerPrefs.GetInt ("Audio") == 1) {
				AudioListener.volume = 1;
				MuteOn.gameObject.SetActive (false);
				SoundOn.gameObject.SetActive(true);
			}
		}
		else {
			AudioListener.volume = 1;
			MuteOn.gameObject.SetActive (false);
			SoundOn.gameObject.SetActive(true);
		}
		if (AudioListener.volume == 0) {
			MuteOn.gameObject.SetActive(true);
			SoundOn.gameObject.SetActive(false);
		}
			
		PlayMusic(0);
		AlertBasketballTab1.gameObject.SetActive (false);
		AlertSoccerTab1.gameObject.SetActive (false);
		AlertBasketballTab2.gameObject.SetActive (false);
		AlertSoccerTab2.gameObject.SetActive (false);

		Menu.gameObject.SetActive (true);
		GameModes.gameObject.SetActive (false);
		LoadingScreen.gameObject.SetActive (false);
		LoadingScreen2.gameObject.SetActive (false);
		Customization1.gameObject.SetActive (false);
		Customization2.gameObject.SetActive (false);

		PickedBorderBasketball1.gameObject.SetActive (false);
		PickedBorderBasketball2.gameObject.SetActive (false);
		PickedBorderBasketball3.gameObject.SetActive (false);

		PickedBorderSoccer1.gameObject.SetActive (false);
		PickedBorderSoccer2.gameObject.SetActive (false);
		PickedBorderSoccer3.gameObject.SetActive (false);
		AlertImage.gameObject.SetActive (false);
		AlertBasketball2.gameObject.SetActive (false);
		AlertBasketball3.gameObject.SetActive (false);
		AlertSoccer2.gameObject.SetActive (false);
		AlertSoccer3.gameObject.SetActive (false);

		if (PlayerPrefs.GetInt ("HasBasketball2") == 1) {
			AlertImage.gameObject.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("HasBasketball3") == 1) {
			AlertImage.gameObject.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("HasSoccerball2") == 1) {
			AlertImage.gameObject.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("HasSoccerball3") == 1) {
			AlertImage.gameObject.SetActive (true);
		}

	}
	

	void Update () {
		if (Customization1.gameObject.activeInHierarchy == true) {
			if (PlayerPrefs.GetInt ("HasBasketball2") == 2) {
				AlertBasketball2.gameObject.SetActive (false);
			}
			if (PlayerPrefs.GetInt ("HasBasketball3") == 2) {
				AlertBasketball3.gameObject.SetActive (false);
			}
		}
		if (Customization2.gameObject.activeInHierarchy == true) {
			if (PlayerPrefs.GetInt ("HasSoccerball2") == 2) {
				AlertSoccer2.gameObject.SetActive (false);
			}
			if (PlayerPrefs.GetInt ("HasSoccerball3") == 2) {
				AlertSoccer3.gameObject.SetActive (false);
			}
		}
	
		if (PlayerPrefs.GetInt ("HasSoccerball2") == 2 && PlayerPrefs.GetInt ("HasSoccerball3") != 1 
			&& PlayerPrefs.GetInt ("HasSoccerball3") != 2) {
			AlertSoccerTab1.gameObject.SetActive (false);
			AlertSoccerTab2.gameObject.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("HasSoccerball3") == 2 && PlayerPrefs.GetInt ("HasSoccerball2") != 1 
			&& PlayerPrefs.GetInt ("HasSoccerball2") != 2) {
			AlertSoccerTab1.gameObject.SetActive (false);
			AlertSoccerTab2.gameObject.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("HasSoccerball2") == 2 && PlayerPrefs.GetInt ("HasSoccerball3") == 2) {
			AlertSoccerTab1.gameObject.SetActive (false);
			AlertSoccerTab2.gameObject.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("HasBasketball2") == 2 && PlayerPrefs.GetInt ("HasBasketball3") != 1 
			&& PlayerPrefs.GetInt ("HasBasketball3") != 2) {
			AlertBasketballTab1.gameObject.SetActive (false);
			AlertBasketballTab2.gameObject.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("HasBasketball3") == 2 && PlayerPrefs.GetInt ("HasBasketball2") != 1 
			&& PlayerPrefs.GetInt ("HasBasketball2") != 2) {
			AlertBasketballTab1.gameObject.SetActive (false);
			AlertBasketballTab2.gameObject.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("HasBasketball2") == 2 && PlayerPrefs.GetInt ("HasBasketball3") == 2) {
			AlertBasketballTab1.gameObject.SetActive (false);
			AlertBasketballTab2.gameObject.SetActive (false);
		}
	
	}
	public void Play(){
		PlaySound (0);
		if (PlayerPrefs.HasKey ("HighScore2")) {
			string gghs = PlayerPrefs.GetFloat ("HighScore2").ToString();
			gghs = gghs.Replace (".", ":");
			HighScoreG1.text = gghs;
		}
		if (PlayerPrefs.HasKey ("HighScore")) {
			HighScoreG2.text = PlayerPrefs.GetInt ("HighScore").ToString ();
		}
		AlertBasketballTab1.gameObject.SetActive (false);
		AlertSoccerTab1.gameObject.SetActive (false);
		AlertBasketballTab2.gameObject.SetActive (false);
		AlertSoccerTab2.gameObject.SetActive (false);

		Menu.gameObject.SetActive (false);
		GameModes.gameObject.SetActive (true);
		LoadingScreen.gameObject.SetActive (false);
		LoadingScreen2.gameObject.SetActive (false);
		Customization1.gameObject.SetActive (false);
		Customization2.gameObject.SetActive (false);
	
		PickedBorderBasketball1.gameObject.SetActive (false);
		PickedBorderBasketball2.gameObject.SetActive (false);
		PickedBorderBasketball3.gameObject.SetActive (false);

		PickedBorderSoccer1.gameObject.SetActive (false);
		PickedBorderSoccer2.gameObject.SetActive (false);
		PickedBorderSoccer3.gameObject.SetActive (false);

		AlertImage.gameObject.SetActive (false);
		AlertBasketball2.gameObject.SetActive (false);
		AlertBasketball3.gameObject.SetActive (false);
		AlertSoccer2.gameObject.SetActive (false);
		AlertSoccer3.gameObject.SetActive (false);
	}
	public void Mode1(){
		PlaySound (0);
		AlertBasketballTab1.gameObject.SetActive (false);
		AlertSoccerTab1.gameObject.SetActive (false);
		AlertBasketballTab2.gameObject.SetActive (false);
		AlertSoccerTab2.gameObject.SetActive (false);

		Menu.gameObject.SetActive (false);
		GameModes.gameObject.SetActive (false);
		LoadingScreen.gameObject.SetActive (true);
		LoadingScreen2.gameObject.SetActive (false);
		Customization1.gameObject.SetActive (false);
		Customization2.gameObject.SetActive (false);

		PickedBorderBasketball1.gameObject.SetActive (false);
		PickedBorderBasketball2.gameObject.SetActive (false);
		PickedBorderBasketball3.gameObject.SetActive (false);

		PickedBorderSoccer1.gameObject.SetActive (false);
		PickedBorderSoccer2.gameObject.SetActive (false);
		PickedBorderSoccer3.gameObject.SetActive (false);

		AlertImage.gameObject.SetActive (false);
		AlertBasketball2.gameObject.SetActive (false);
		AlertBasketball3.gameObject.SetActive (false);
		AlertSoccer2.gameObject.SetActive (false);
		AlertSoccer3.gameObject.SetActive (false);
	}
	public void Mode2(){
		PlaySound (0);
		AlertBasketballTab1.gameObject.SetActive (false);
		AlertSoccerTab1.gameObject.SetActive (false);
		AlertBasketballTab2.gameObject.SetActive (false);
		AlertSoccerTab2.gameObject.SetActive (false);

		Menu.gameObject.SetActive (false);
		GameModes.gameObject.SetActive (false);
		LoadingScreen.gameObject.SetActive (false);
		LoadingScreen2.gameObject.SetActive (true);
		Customization1.gameObject.SetActive (false);
		Customization2.gameObject.SetActive (false);

		PickedBorderBasketball1.gameObject.SetActive (false);
		PickedBorderBasketball2.gameObject.SetActive (false);
		PickedBorderBasketball3.gameObject.SetActive (false);
	
		PickedBorderSoccer1.gameObject.SetActive (false);
		PickedBorderSoccer2.gameObject.SetActive (false);
		PickedBorderSoccer3.gameObject.SetActive (false);

		AlertImage.gameObject.SetActive (false);
		AlertBasketball2.gameObject.SetActive (false);
		AlertBasketball3.gameObject.SetActive (false);
		AlertSoccer2.gameObject.SetActive (false);
		AlertSoccer3.gameObject.SetActive (false);
	}
	public void Tutorial(){
		PlaySound (0);
		SceneManager.LoadScene ("Tutorial Scene");
	}
	public void Customize(){
		PlaySound (0);
		if (PlayerPrefs.HasKey ("Unlock Basketball 3")) {
			ballsLeftsBB3.text=""+ PlayerPrefs.GetInt ("Unlock Basketball 3") +"/1000";
		}
		Menu.gameObject.SetActive (false);
		GameModes.gameObject.SetActive (false);
		LoadingScreen.gameObject.SetActive (false);
		LoadingScreen2.gameObject.SetActive (false);
		Customization1.gameObject.SetActive (true);
		Customization2.gameObject.SetActive (false);

		PickedBorderBasketball1.gameObject.SetActive (false);
		PickedBorderBasketball2.gameObject.SetActive (false);
		PickedBorderBasketball3.gameObject.SetActive (false);

		PickedBorderSoccer1.gameObject.SetActive (false);
		PickedBorderSoccer2.gameObject.SetActive (false);
		PickedBorderSoccer3.gameObject.SetActive (false);

		LockedBasketball2.gameObject.SetActive (true);
		UnlockedBasketball2.gameObject.SetActive (false);
		LockedBasketball3.gameObject.SetActive (true);
		UnlockedBasketball3.gameObject.SetActive (false);

		LockedSoccer2.gameObject.SetActive (true);
		UnlockedSoccer2.gameObject.SetActive (false);
		LockedSoccer3.gameObject.SetActive (true);
		UnlockedSoccer3.gameObject.SetActive (false);
	
		AlertImage.gameObject.SetActive (false);
		AlertBasketball2.gameObject.SetActive (false);
		AlertBasketball3.gameObject.SetActive (false);
		AlertSoccer2.gameObject.SetActive (false);
		AlertSoccer3.gameObject.SetActive (false);
	
		AlertBasketballTab1.gameObject.SetActive (false);
		AlertSoccerTab1.gameObject.SetActive (false);
		AlertBasketballTab2.gameObject.SetActive (false);
		AlertSoccerTab2.gameObject.SetActive (false);

		if (PlayerPrefs.HasKey ("Unlock Basketball 2")) {
			if (PlayerPrefs.GetInt ("Unlock Basketball 2") == 1) {
				LockedBasketball2.gameObject.SetActive (false);
				UnlockedBasketball2.gameObject.SetActive (true);

				if (PlayerPrefs.GetInt ("HasBasketball2") == 1) {
					AlertBasketball2.gameObject.SetActive (true);

					AlertBasketballTab1.gameObject.SetActive (true);
					AlertBasketballTab2.gameObject.SetActive (true);
				}
			}
		}
		if (PlayerPrefs.HasKey ("Unlock Basketball 3")) {
			if (PlayerPrefs.GetInt ("Unlock Basketball 3") >= 1000) {
				LockedBasketball3.gameObject.SetActive (false);
				UnlockedBasketball3.gameObject.SetActive (true);

				if (PlayerPrefs.GetInt ("HasBasketball3") == 1) {
					AlertBasketball3.gameObject.SetActive (true);

					AlertBasketballTab1.gameObject.SetActive (true);
					AlertBasketballTab2.gameObject.SetActive (true);
				}
			}
		}

		if (PlayerPrefs.HasKey ("Unlock Soccerball 2")) {
			if (PlayerPrefs.GetInt ("Unlock Soccerball 2") == 1) {
				if (PlayerPrefs.GetInt ("HasSoccerball2") == 1) {
					AlertSoccerTab1.gameObject.SetActive (true);
					AlertSoccerTab2.gameObject.SetActive (true);
				}
			}
		}

		if (PlayerPrefs.HasKey ("Unlock Soccerball 3")) {
			if (PlayerPrefs.GetInt ("Unlock Soccerball 3") >= 1000) {
				if (PlayerPrefs.GetInt ("HasSoccerball3") == 1) {
					AlertSoccerTab1.gameObject.SetActive (true);
					AlertSoccerTab2.gameObject.SetActive (true);
				}
			}
		}


		if (PlayerPrefs.HasKey ("Initalize Basketball")) {
			if (PlayerPrefs.GetInt ("Initalize Basketball") == 1) {
				PickedBorderBasketball1.gameObject.SetActive (true);
				PickedBorderBasketball2.gameObject.SetActive (false);
				PickedBorderBasketball3.gameObject.SetActive (false);
			}
			if (PlayerPrefs.GetInt ("Initalize Basketball") == 2) {
				PickedBorderBasketball1.gameObject.SetActive (false);
				PickedBorderBasketball2.gameObject.SetActive (true);
				PickedBorderBasketball3.gameObject.SetActive (false);
			}
		
			if (PlayerPrefs.GetInt ("Initalize Basketball") == 3) {
				PickedBorderBasketball1.gameObject.SetActive (false);
				PickedBorderBasketball2.gameObject.SetActive (false);
				PickedBorderBasketball3.gameObject.SetActive (true);
			}
		}

	}
	public void Custom1(){
		PlaySound (0);
		if (PlayerPrefs.HasKey ("Unlock Basketball 3")) {
			ballsLeftsBB3.text=""+ PlayerPrefs.GetInt ("Unlock Basketball 3") +"/1000";
		}
		Menu.gameObject.SetActive (false);
		GameModes.gameObject.SetActive (false);
		LoadingScreen.gameObject.SetActive (false);
		LoadingScreen2.gameObject.SetActive (false);
		Customization1.gameObject.SetActive (true);
		Customization2.gameObject.SetActive (false);
	
		PickedBorderBasketball1.gameObject.SetActive (false);
		PickedBorderBasketball2.gameObject.SetActive (false);
		PickedBorderBasketball3.gameObject.SetActive (false);

		PickedBorderSoccer1.gameObject.SetActive (false);
		PickedBorderSoccer2.gameObject.SetActive (false);
		PickedBorderSoccer3.gameObject.SetActive (false);

		LockedBasketball2.gameObject.SetActive (true);
		UnlockedBasketball2.gameObject.SetActive (false);
		LockedBasketball3.gameObject.SetActive (true);
		UnlockedBasketball3.gameObject.SetActive (false);


		LockedSoccer2.gameObject.SetActive (true);
		UnlockedSoccer2.gameObject.SetActive (false);
		LockedSoccer3.gameObject.SetActive (true);
		UnlockedSoccer3.gameObject.SetActive (false);

		if (PlayerPrefs.HasKey ("Unlock Basketball 2")) {
			if (PlayerPrefs.GetInt ("Unlock Basketball 2") == 1) {
				LockedBasketball2.gameObject.SetActive (false);
				UnlockedBasketball2.gameObject.SetActive (true);

				if (PlayerPrefs.GetInt ("HasBasketball2") == 1) {

					AlertBasketball2.gameObject.SetActive (true);

					AlertBasketballTab1.gameObject.SetActive (true);
					AlertBasketballTab2.gameObject.SetActive (true);
				}
			}
		}

		if (PlayerPrefs.HasKey ("Unlock Basketball 3")) {
			if (PlayerPrefs.GetInt ("Unlock Basketball 3") >= 1000) {
				LockedBasketball3.gameObject.SetActive (false);
				UnlockedBasketball3.gameObject.SetActive (true);

				if (PlayerPrefs.GetInt ("HasBasketball3") == 1) {
					AlertBasketball3.gameObject.SetActive (true);

					AlertBasketballTab1.gameObject.SetActive (true);
					AlertBasketballTab2.gameObject.SetActive (true);
				}
			}
		}



		if (PlayerPrefs.HasKey ("Unlock Soccerball 2")) {
			if (PlayerPrefs.GetInt ("Unlock Soccerball 2") == 1) {
				if (PlayerPrefs.GetInt ("HasSoccerball2") == 1) {
					AlertSoccerTab1.gameObject.SetActive (true);
					AlertSoccerTab2.gameObject.SetActive (true);
				}
			}
		}

		if (PlayerPrefs.HasKey ("Unlock Soccerball 3")) {
			if (PlayerPrefs.GetInt ("Unlock Soccerball 3") >= 1000) {
				if (PlayerPrefs.GetInt ("HasSoccerball3") == 1) {
					AlertSoccerTab1.gameObject.SetActive (true);
					AlertSoccerTab2.gameObject.SetActive (true);
				}
			}
		}
			
		if (PlayerPrefs.HasKey ("Initalize Basketball")) {
			if (PlayerPrefs.GetInt ("Initalize Basketball") == 1) {
				PickedBorderBasketball1.gameObject.SetActive (true);
				PickedBorderBasketball2.gameObject.SetActive (false);
				PickedBorderBasketball3.gameObject.SetActive (false);
			}
			if (PlayerPrefs.GetInt ("Initalize Basketball") == 2) {
				PickedBorderBasketball1.gameObject.SetActive (false);
				PickedBorderBasketball2.gameObject.SetActive (true);
				PickedBorderBasketball3.gameObject.SetActive (false);
			}
		
			if (PlayerPrefs.GetInt ("Initalize Basketball") == 3) {
				PickedBorderBasketball1.gameObject.SetActive (false);
				PickedBorderBasketball2.gameObject.SetActive (false);
				PickedBorderBasketball3.gameObject.SetActive (true);
			}
		}
	}
	public void Custom2(){
		PlaySound (0);
		if (PlayerPrefs.HasKey ("Unlock Soccerball 3")) {
			ballsLeftsSB3.text=""+ PlayerPrefs.GetInt ("Unlock Soccerball 3") +"/1000";
		}
		Menu.gameObject.SetActive (false);
		GameModes.gameObject.SetActive (false);
		LoadingScreen.gameObject.SetActive (false);
		LoadingScreen2.gameObject.SetActive (false);
		Customization1.gameObject.SetActive (false);
		Customization2.gameObject.SetActive (true);

		PickedBorderBasketball1.gameObject.SetActive (false);
		PickedBorderBasketball2.gameObject.SetActive (false);
		PickedBorderBasketball3.gameObject.SetActive (false);
		//
		PickedBorderSoccer1.gameObject.SetActive (false);
		PickedBorderSoccer2.gameObject.SetActive (false);
		PickedBorderSoccer3.gameObject.SetActive (false);
		if (PlayerPrefs.HasKey ("Unlock Soccerball 2")) {

			if (PlayerPrefs.GetInt ("Unlock Soccerball 2") == 1) {
				LockedSoccer2.gameObject.SetActive (false);
				UnlockedSoccer2.gameObject.SetActive (true);

				if (PlayerPrefs.GetInt ("HasSoccerball2") == 1) {
					AlertSoccer2.gameObject.SetActive (true);

					AlertSoccerTab1.gameObject.SetActive (true);
					AlertSoccerTab2.gameObject.SetActive (true);
				}
			}
		}
		if (PlayerPrefs.HasKey ("Unlock Soccerball 3")) {
			if (PlayerPrefs.GetInt ("Unlock Soccerball 3") >= 1000) {
				LockedSoccer3.gameObject.SetActive (false);
				UnlockedSoccer3.gameObject.SetActive (true);

				if (PlayerPrefs.GetInt ("HasSoccerball3") == 1) {
					AlertSoccer3.gameObject.SetActive (true);

					AlertSoccerTab1.gameObject.SetActive (true);
					AlertSoccerTab2.gameObject.SetActive (true);
				}
			}
		}

		if (PlayerPrefs.HasKey ("Initalize Soccer")) {
			if (PlayerPrefs.GetInt ("Initalize Soccer") == 1) {
				PickedBorderSoccer1.gameObject.SetActive (true);
				PickedBorderSoccer2.gameObject.SetActive (false);
				PickedBorderSoccer3.gameObject.SetActive (false);
			}
			if (PlayerPrefs.GetInt ("Initalize Soccer") == 2) {
				PickedBorderSoccer1.gameObject.SetActive (false);
				PickedBorderSoccer2.gameObject.SetActive (true);
				PickedBorderSoccer3.gameObject.SetActive (false);
			}
			if (PlayerPrefs.GetInt ("Initalize Soccer") == 3) {
				PickedBorderSoccer1.gameObject.SetActive (false);
				PickedBorderSoccer2.gameObject.SetActive (false);
				PickedBorderSoccer3.gameObject.SetActive (true);
			}
		}
	}

	public void BasketballBorder1(){
		PlaySound (0);
		PlayerPrefs.SetInt ("Initalize Basketball", 1);
		PickedBorderBasketball1.gameObject.SetActive (true);
		PickedBorderBasketball2.gameObject.SetActive (false);
		PickedBorderBasketball3.gameObject.SetActive (false);
	}
	public void BasketballBorder2(){
		PlaySound (0);
		PlayerPrefs.SetInt ("Initalize Basketball", 2);
		PlayerPrefs.SetInt ("HasBasketball2", 2);
		PickedBorderBasketball1.gameObject.SetActive (false);
		PickedBorderBasketball2.gameObject.SetActive (true);
		PickedBorderBasketball3.gameObject.SetActive (false);
	}
	public void BasketballBorder3(){
		PlaySound (0);
		PlayerPrefs.SetInt ("Initalize Basketball", 3);
		PlayerPrefs.SetInt ("HasBasketball3", 2);
		PickedBorderBasketball1.gameObject.SetActive (false);
		PickedBorderBasketball2.gameObject.SetActive (false);
		PickedBorderBasketball3.gameObject.SetActive (true);
	}

	public void SoccerBorder1(){
		PlaySound (0);
		PlayerPrefs.SetInt ("Initalize Soccer", 1);
		PickedBorderSoccer1.gameObject.SetActive (true);
		PickedBorderSoccer2.gameObject.SetActive (false);
		PickedBorderSoccer3.gameObject.SetActive (false);
	}
	public void SoccerBorder2(){
		PlaySound (0);
		PlayerPrefs.SetInt ("Initalize Soccer", 2);
		PlayerPrefs.SetInt ("HasSoccerball2", 2);
		PickedBorderSoccer1.gameObject.SetActive (false);
		PickedBorderSoccer2.gameObject.SetActive (true);
		PickedBorderSoccer3.gameObject.SetActive (false);
	}
	public void SoccerBorder3(){
		PlaySound (0);
		PlayerPrefs.SetInt ("Initalize Soccer", 3);
		PlayerPrefs.SetInt ("HasSoccerball3", 2);
		PickedBorderSoccer1.gameObject.SetActive (false);
		PickedBorderSoccer2.gameObject.SetActive (false);
		PickedBorderSoccer3.gameObject.SetActive (true);
	}

	public void Home(){
	
		PlaySound (0);
		Menu.gameObject.SetActive (true);
		GameModes.gameObject.SetActive (false);
		LoadingScreen.gameObject.SetActive (false);
		LoadingScreen2.gameObject.SetActive (false);
		Customization1.gameObject.SetActive (false);
		Customization2.gameObject.SetActive (false);
	
		PickedBorderBasketball1.gameObject.SetActive (false);
		PickedBorderBasketball2.gameObject.SetActive (false);
		PickedBorderBasketball3.gameObject.SetActive (false);

		PickedBorderSoccer1.gameObject.SetActive (false);
		PickedBorderSoccer2.gameObject.SetActive (false);
		PickedBorderSoccer3.gameObject.SetActive (false);
		AlertImage.gameObject.SetActive (false);
		AlertBasketball2.gameObject.SetActive (false);
		AlertBasketball3.gameObject.SetActive (false);
		AlertSoccer2.gameObject.SetActive (false);
		AlertSoccer3.gameObject.SetActive (false);

		if (PlayerPrefs.GetInt ("HasBasketball2") == 1) {
			AlertImage.gameObject.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("HasBasketball3") == 1) {
			AlertImage.gameObject.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("HasSoccerball2") == 1) {
			AlertImage.gameObject.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("HasSoccerball3") == 1) {
			AlertImage.gameObject.SetActive (true);
		}
	}

	public void MuteGame(){
		if (AudioListener.volume == 0) {
			AudioListener.volume = 1;
			PlayerPrefs.SetInt ("Audio", 1);
			MuteOn.gameObject.SetActive(false);
			SoundOn.gameObject.SetActive(true);
		}
		else if (AudioListener.volume == 1) {
			AudioListener.volume = 0;
			PlayerPrefs.SetInt ("Audio", 0);
			MuteOn.gameObject.SetActive(true);
			SoundOn.gameObject.SetActive(false);
		}
	}

	public void RateGame(){
		Application.OpenURL(ANDROID_RATE_URL);
	}
}
