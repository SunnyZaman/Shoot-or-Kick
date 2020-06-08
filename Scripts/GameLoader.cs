using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour {

	void Start () {
		if (PlayerPrefs.HasKey ("Tutorial")) {
			SceneManager.LoadScene ("Menu Scene");
		}
		else {
			PlayerPrefs.SetInt ("Tutorial", 1);
			SceneManager.LoadScene ("Tutorial Scene");
		}

		if (PlayerPrefs.HasKey ("Initalize Soccer") && PlayerPrefs.HasKey ("Initalize Basketball")) {
			//Do Nothing
		} else {
			PlayerPrefs.SetInt ("Initalize Soccer", 1);
			PlayerPrefs.SetInt ("Initalize Basketball", 1);
		}
		
	}

}
