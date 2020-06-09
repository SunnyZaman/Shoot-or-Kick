using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.SoundManagerNamespace; 
public class TimerScript : MonoBehaviour {
	Image fillImg;
	public Transform timeBar;

	private int gameCounter;
	public AudioSource[] MusicAudioSources;
	public bool startGame;
	int intTime;
	int minutes, seconds, fraction;

	float timeAmount = 12f; //20
	float time;
	public Text timerText;
	KickSoccerBall soccerScript;
	ShootBasketball basketballScript;
	GameObject theSoccer;
	GameObject theBasketball;

	public int consecutiveRight;
	public int consecutiveWrong;

	public Text reduceTime;
	public Text increaseTime;
	public float fadeOutSpeed = 0.01f;
	bool started=false;

	public Transform GameOverScreen;
	public Transform SoccerNet;
	public Transform BasketballNet;
	public Transform ScoreHolder;
	public Transform TimeHolder;
	public Transform Achievement;

	public Text gameOveHighScore;
	public Text gameOverScore;

	public Color achieveColor;
	public float fadeOutSpeed2 = 0.01f;
	bool started2=false;
	bool started3 = false;

	float time2;

	private void StopOldMusic(){
		SoundManager.StopAll();
	}

	private void PlayOneTimeMusic(int index){
		MusicAudioSources[index].PlayOneShotSoundManaged(MusicAudioSources[index].clip);
	}
	public void startFadeOut() {
		started2 = true;
	}
	public void startFadeOut3() {
		started3 = true;
	}
	void Start () {
		time2 = 0;
		fillImg = timeBar.gameObject.GetComponent<Image> ();

		gameCounter = 0;
		achieveColor = Achievement.gameObject.GetComponent<Image> ().color;
		achieveColor.a = 0;
		Achievement.gameObject.GetComponent<Image> ().color = achieveColor;

		GameOverScreen.gameObject.SetActive (false);
		SoccerNet.gameObject.SetActive (true);
		BasketballNet.gameObject.SetActive (true);
		ScoreHolder.gameObject.SetActive (true);
		TimeHolder.gameObject.SetActive (true);
		Achievement.gameObject.SetActive (false);

		startGame = false;
		 theSoccer = GameObject.Find ("Soccerball");
		if (theSoccer != null) {
			soccerScript = theSoccer.GetComponent<KickSoccerBall> ();
		}
		 theBasketball = GameObject.Find ("Basketball");
		if (theBasketball != null) {
			basketballScript = theBasketball.GetComponent<ShootBasketball> ();
		}
		time = timeAmount;
	}
	public void startFadeOut2() {
		started = true;
	}

	void Update () {
		Color colrA = Achievement.gameObject.GetComponent<Image> ().color;
		if (started && colrA.a < 1) {            
			colrA.a += fadeOutSpeed;
			colrA.a = Mathf.Min (colrA.a,1);;
			if (colrA.a == 0) {
			}
			Achievement.gameObject.GetComponent<Image> ().color = colrA;
		}
		if(time>=15){

			time = 15;
		}
		if(time2>=15){
			time2=15;
		}


		if(startGame ==true){
		if (time > 0) {
			time -= Time.deltaTime;
				time2 += Time.deltaTime;
				fillImg.fillAmount = time2/timeAmount;
				int intTime = (int)time;
				int minutes = intTime / 60;
				int seconds = intTime % 60;
				float fraction = time * 1000;
				fraction = (fraction % 1000);
				fraction = fraction / 10;
				string timeText = string.Format ("{0:00}:{1:00}", seconds, fraction);
				timerText.text = timeText;
		}
			if (time <= 0) {
				timerText.text = "0:00";
				fillImg.fillAmount = 1;
				GameObject[] sObjects = GameObject.FindGameObjectsWithTag ("Soccerball");
				if (sObjects != null) {
					for (int i = 0; i < sObjects.Length; i++) {
						Destroy (sObjects [i]);
					}
				}
				GameObject[] bObjects = GameObject.FindGameObjectsWithTag ("Basketball");
				if (bObjects != null) {
					for (int i = 0; i < bObjects.Length; i++) {
						Destroy (bObjects [i]);
					}
				}

				if (theSoccer != null) {
					soccerScript.isGameDone = true;
				}
				if (theBasketball != null) {
					basketballScript.isGameDone = true;
				}
				if (gameCounter == 0) {
					StopOldMusic ();
					PlayOneTimeMusic (0);
					gameCounter = 1;
				}
				if (PlayerPrefs.HasKey ("Score")) {
					int score = PlayerPrefs.GetInt ("Score");
					if (PlayerPrefs.HasKey ("HighScore")) {
						if (PlayerPrefs.GetInt ("HighScore") < score) {
							PlayerPrefs.SetInt ("HighScore", score);
						}
					} else {
						PlayerPrefs.SetInt ("HighScore", score);
					}
				}
				GameOverScreen.gameObject.SetActive (true);
				SoccerNet.gameObject.SetActive (false);
				BasketballNet.gameObject.SetActive (false);
				ScoreHolder.gameObject.SetActive (false);
				TimeHolder.gameObject.SetActive (false);
				if (PlayerPrefs.HasKey ("Score")) {
					gameOverScore.text = "" + PlayerPrefs.GetInt ("Score");
				}
				if (PlayerPrefs.HasKey ("HighScore")) {
					gameOveHighScore.text = "" + PlayerPrefs.GetInt ("HighScore");
				} 

				if (PlayerPrefs.GetInt ("Unlock Soccerball 2") == 1) {
					if (PlayerPrefs.HasKey ("HasSoccerball2")) {
						//do nothing
					} 
					else {
						PlayerPrefs.SetInt ("HasSoccerball2", 1);
						Achievement.gameObject.SetActive (true);
						startFadeOut2 ();
					}
				}

				if (PlayerPrefs.GetInt ("Unlock Soccerball 3") >= 1000) {
					if (PlayerPrefs.HasKey ("HasSoccerball3")) {
						//do nothing
					} 
					else {
						PlayerPrefs.SetInt ("HasSoccerball3", 1);
						Achievement.gameObject.SetActive (true);
						startFadeOut2 ();
					}
				}

				if (PlayerPrefs.GetInt ("Unlock Basketball 3") >= 1000) {
					if (PlayerPrefs.HasKey ("HasBasketball3")) {
						//do nothing
					} 
					else {
						PlayerPrefs.SetInt ("HasBasketball3", 1);
						Achievement.gameObject.SetActive (true);
						startFadeOut2 ();
					}
				}
		}
		Color colr1 = reduceTime.color;
		if (started2 && colr1.a > 0) {            
			colr1.a -= fadeOutSpeed;
			colr1.a = Mathf.Max (0, colr1.a);
			reduceTime.color = colr1;
		}
		Color colrIncreaseTime = increaseTime.color;
		if (started3 && colrIncreaseTime.a > 0) {            
			colrIncreaseTime.a -= fadeOutSpeed;
			colrIncreaseTime.a = Mathf.Max (0, colrIncreaseTime.a);
			increaseTime.color = colrIncreaseTime;
		}
	}

	}

	public void IncreaseTime(int value){
		consecutiveRight+=value;
		if (value == 0) {
			consecutiveRight = 0;
		}
		if (timerText.text != null) {
			if (consecutiveRight ==5) {
				Color newc = increaseTime.color;
				newc.a = 1;
				increaseTime.color = newc;
				increaseTime.gameObject.SetActive (true);
				startFadeOut3 ();
				consecutiveRight = 0;
				time += 2f;   //-2f
				time2 -= 2f;  //+2f
			}
		}
	}

	public void DecreaseTime(int value){
		consecutiveWrong+=value;
		if (value == 0) {
			consecutiveWrong = 0;
		}
		if (timerText.text != null) {
			if (consecutiveWrong ==1) {
				Color newc = reduceTime.color;
				newc.a = 1;
				reduceTime.color = newc;
				reduceTime.gameObject.SetActive (true);
				startFadeOut ();
				consecutiveWrong = 0;
				time -= 3f;    //-2f
				time2 += 3f;   //+2f
			}
		}
	}
}
