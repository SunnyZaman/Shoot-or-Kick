using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.SoundManagerNamespace;

public class ScoreScript : MonoBehaviour {
	public AudioSource[] SoundAudioSources;

	private bool hasPlayerSwiped;

	public Text scoreText;
	public int score = 0;
	private bool buzz=false;

	public Transform LeftBuzzer;
	public Transform RightBuzzer;

	public Text reduceScore;
	public float fadeOutSpeed = 0.01f;
	bool started=false;

	private void PlaySound(int index)
	{

		SoundAudioSources[index].PlayOneShotSoundManaged(SoundAudioSources[index].clip);
	}

	void Start(){
		hasPlayerSwiped = false;
	}

	public void startFadeOut() {
		started = true;
	}
	void Update () {
		if (hasPlayerSwiped == false) {
			PlayerPrefs.SetInt ("Score", 0);
		}
		Color colr = reduceScore.color;
		if (started && colr.a > 0) {            
			colr.a -= fadeOutSpeed;
			colr.a = Mathf.Max (0, colr.a);
			if (colr.a == 0) {
				LeftBuzzer.gameObject.SetActive (false);
				RightBuzzer.gameObject.SetActive (false);
			}
			reduceScore.color = colr;
		}
	}
	public void IncrementScore(int value){
		hasPlayerSwiped = true;
		score+=value;
		PlaySound (1);
		if (scoreText.text != null) {
			if (score <= 0) {
				score = 0;
			}
			if (score >= 50) { 
				PlayerPrefs.SetInt ("Unlock Soccerball 2", 1);
			}
			PlayerPrefs.SetInt ("Score", score);
			scoreText.text = "" + score;
		}
	}
	public void useBuzzers(bool useBuzzer){
		buzz = useBuzzer;
		if (buzz == true) {
			PlaySound (0);
			Color newc = reduceScore.color;
			newc.a = 1;
			reduceScore.color = newc;
			reduceScore.gameObject.SetActive (true);
			LeftBuzzer.gameObject.SetActive (true);
			RightBuzzer.gameObject.SetActive (true);
			startFadeOut ();
		} 
		else {
			reduceScore.gameObject.SetActive (false);
			LeftBuzzer.gameObject.SetActive (false);
			RightBuzzer.gameObject.SetActive (false);
		}
	}
}