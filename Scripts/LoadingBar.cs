using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DigitalRuby.SoundManagerNamespace; //

public class LoadingBar : MonoBehaviour {
	Image fillImg;
	float timeAmt = 5f;
	float time;

	//public Transform CityBackground;
	public Transform CityBackgroundNight;

	public Transform Building1;
	public Transform Building2;
	public Transform Building3;
	public Transform Building4;
	public Transform Building5;
	public Transform Building6;
	public Transform Building7;
	public Transform NightSky;


	public Color achieveColor1;
	public Color achieveColor2;
	public Color achieveColor3;
	public Color achieveColor4;
	public Color achieveColor5;
	public Color achieveColor6;
	public Color achieveColor7;
	public Color achieveColor8;
	public float fadeOutSpeed = 0.01f;
	bool started=false;


	public void startFadeOut() {
		started = true;
	}

	private void StopOldMusic(){
		//SoundManager.ClearPersistedSounds ();
		SoundManager.StopAll();
	}
	// Use this for initialization
	void Start () {
		

		achieveColor1 = Building1.gameObject.GetComponent<SpriteRenderer> ().color;
		achieveColor1.a = 0;
		Building1.gameObject.GetComponent<SpriteRenderer> ().color = achieveColor1;

		achieveColor2 = Building2.gameObject.GetComponent<SpriteRenderer> ().color;
		achieveColor2.a = 0;
		Building2.gameObject.GetComponent<SpriteRenderer> ().color = achieveColor2;

		achieveColor3 = Building3.gameObject.GetComponent<SpriteRenderer> ().color;
		achieveColor3.a = 0;
		Building3.gameObject.GetComponent<SpriteRenderer> ().color = achieveColor3;

		achieveColor4 = Building4.gameObject.GetComponent<SpriteRenderer> ().color;
		achieveColor4.a = 0;
		Building4.gameObject.GetComponent<SpriteRenderer> ().color = achieveColor4;

		achieveColor5 = Building5.gameObject.GetComponent<SpriteRenderer> ().color;
		achieveColor5.a = 0;
		Building5.gameObject.GetComponent<SpriteRenderer> ().color = achieveColor5;

		achieveColor6 = Building6.gameObject.GetComponent<SpriteRenderer> ().color;
		achieveColor6.a = 0;
		Building6.gameObject.GetComponent<SpriteRenderer> ().color = achieveColor6;

		achieveColor7 = Building7.gameObject.GetComponent<SpriteRenderer> ().color;
		achieveColor7.a = 0;
		Building7.gameObject.GetComponent<SpriteRenderer> ().color = achieveColor7;

		achieveColor8 = NightSky.gameObject.GetComponent<SpriteRenderer> ().color;
		achieveColor8.a = 0;
		NightSky.gameObject.GetComponent<SpriteRenderer> ().color = achieveColor8;



		//CityBackground.gameObject.SetActive (false);
		CityBackgroundNight.gameObject.SetActive (false);
		//StopOldMusic ();
		fillImg = this.GetComponent<Image> ();
		time = 0;
	}

	// Update is called once per frame
	void Update () {

		Color colr1 = Building1.gameObject.GetComponent<SpriteRenderer> ().color;
		Color colr2 = Building2.gameObject.GetComponent<SpriteRenderer> ().color;
		Color colr3 = Building3.gameObject.GetComponent<SpriteRenderer> ().color;
		Color colr4 = Building4.gameObject.GetComponent<SpriteRenderer> ().color;
		Color colr5 = Building5.gameObject.GetComponent<SpriteRenderer> ().color;
		Color colr6 = Building6.gameObject.GetComponent<SpriteRenderer> ().color;
		Color colr7 = Building7.gameObject.GetComponent<SpriteRenderer> ().color;
		Color colr8 = NightSky.gameObject.GetComponent<SpriteRenderer> ().color;
		if (started && colr1.a < 1 && colr2.a < 1 && colr3.a < 1 && colr4.a < 1 && colr5.a < 1 && colr6.a < 1
			&& colr7.a < 1 && colr8.a < 1) {            
			colr1.a += fadeOutSpeed;
			colr1.a = Mathf.Min (colr1.a,1);
			colr2.a += fadeOutSpeed;
			colr2.a = Mathf.Min (colr2.a,1);
			colr3.a += fadeOutSpeed;
			colr3.a = Mathf.Min (colr3.a,1);
			colr4.a += fadeOutSpeed;
			colr4.a = Mathf.Min (colr4.a,1);
			colr5.a += fadeOutSpeed;
			colr5.a = Mathf.Min (colr5.a,1);
			colr6.a += fadeOutSpeed;
			colr6.a = Mathf.Min (colr6.a,1);
			colr7.a += fadeOutSpeed;
			colr7.a = Mathf.Min (colr7.a,1);
			colr8.a += fadeOutSpeed;
			colr8.a = Mathf.Min (colr8.a,1);
			//print (colr.a);
			if (colr1.a == 0) {
			}
			Building1.gameObject.GetComponent<SpriteRenderer> ().color = colr1;
			Building2.gameObject.GetComponent<SpriteRenderer> ().color = colr2;
			Building3.gameObject.GetComponent<SpriteRenderer> ().color = colr3;
			Building4.gameObject.GetComponent<SpriteRenderer> ().color = colr4;
			Building5.gameObject.GetComponent<SpriteRenderer> ().color = colr5;
			Building6.gameObject.GetComponent<SpriteRenderer> ().color = colr6;
			Building7.gameObject.GetComponent<SpriteRenderer> ().color = colr7;
			NightSky.gameObject.GetComponent<SpriteRenderer> ().color = colr8;

		}

		/*if (time < 10) {
			time += Time.deltaTime;
			fillImg.fillAmount = time / timeAmt;	
		}*/
		//New Version
		if (time < 9) {
			time += Time.deltaTime;
			fillImg.fillAmount = time / timeAmt;
			if (time >= 2.5f) {
				CityBackgroundNight.gameObject.SetActive (true);
				startFadeOut ();
			}
			if (time >= 6) {
				StopOldMusic ();
			}
			if (time >= 7) {
				//print("1");
				//Open Game Scene1
				SceneManager.LoadScene ("Game Scene");
			}
		}
	}
}
