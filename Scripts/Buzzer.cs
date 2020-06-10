using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.SoundManagerNamespace; 

public class TutorialBuzzer : MonoBehaviour {

	private bool buzz=false;

	public Transform LeftBuzzer;
	public Transform RightBuzzer;

	public Text tempText;
	public float fadeOutSpeed = 0.01f;
	bool started=false;

	public AudioSource[] SoundAudioSources;

	void Awake(){
		Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
	}

	private void PlaySound(int index)
	{

		SoundAudioSources[index].PlayOneShotSoundManaged(SoundAudioSources[index].clip);
	}
		

	public void startFadeOut() {
		started = true;
	}
	void Update () {
		
		Color colr = tempText.color;
		if (started && colr.a > 0) {            
			colr.a -= fadeOutSpeed;
			colr.a = Mathf.Max (0, colr.a);
			if (colr.a == 0) {
				LeftBuzzer.gameObject.SetActive (false);
				RightBuzzer.gameObject.SetActive (false);
			}
			tempText.color = colr;
		}
	}
	public void correct(){
		PlaySound (1);
	}

	public void useBuzzers(bool useBuzzer){
		buzz = useBuzzer;
		if (buzz == true) {
			PlaySound (0);
			Color newc = tempText.color;
			newc.a = 1;
			tempText.color = newc;
			LeftBuzzer.gameObject.SetActive (true);
			RightBuzzer.gameObject.SetActive (true);
			startFadeOut ();
		} 
		else {
			LeftBuzzer.gameObject.SetActive (false);
			RightBuzzer.gameObject.SetActive (false);
		}
	}
}
