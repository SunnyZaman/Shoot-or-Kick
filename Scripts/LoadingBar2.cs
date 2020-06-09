using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DigitalRuby.SoundManagerNamespace; 

public class LoadingBar2 : MonoBehaviour {

	Image fillImg;
	float timeAmt = 5f;
	float time;

	private void StopOldMusic(){
		SoundManager.StopAll();
	}

	void Start () {
		fillImg = this.GetComponent<Image> ();
		time = 0;
	}

	void Update () {
		if (time < 9) {
			time += Time.deltaTime;
			fillImg.fillAmount = time / timeAmt;
			if (time >= 6) {
				StopOldMusic ();
			}
			if (time >= 7) {
				SceneManager.LoadScene ("Game Scene 2");
			}
		}
	}
}
