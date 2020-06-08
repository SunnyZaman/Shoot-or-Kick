using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.SoundManagerNamespace; 

public class OpeningScript : MonoBehaviour {
	TimerScript timerScript;
	public Text openingText;
	float time;
	public GameObject [] hazards;
	private int hazardToSpawn;
	private Vector3 spawnPos = new Vector3 (0, -3.08f,-3.92f);
	private int count;
	public AudioSource[] SoundAudioSources;
	public AudioSource[] MusicAudioSources;

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


	void Start () {
		count = 0;
		time = 0;
		openingText.text = "READY";
		PlaySound (0);
		timerScript = GameObject.FindWithTag("ui").GetComponent<TimerScript> ();
	}
	void Update () {
		time += Time.deltaTime;
		if (time > 1 && time<1.3f) {
			openingText.text = "SET";
			PlaySound (1);
		}
		if (time > 2 && time<2.5f) {
			openingText.text = "GO";
			PlaySound (2);
			PlayMusic(0);
		}
		if (time > 2.3f) {
			openingText.text = "";
			timerScript.startGame = true;
			SpawnBall ();
		}
	}
	void SpawnBall(){
		if (count == 0) {
			if (PlayerPrefs.HasKey ("Initalize Basketball")) {
				if (PlayerPrefs.HasKey ("Initalize Soccer")) {
					if (PlayerPrefs.GetInt ("Initalize Basketball") == 1 && PlayerPrefs.GetInt ("Initalize Soccer") == 1) {
						hazardToSpawn = UnityEngine.Random.Range (0, 2);
					}

					if (PlayerPrefs.GetInt ("Initalize Basketball") == 1 && PlayerPrefs.GetInt ("Initalize Soccer") == 2) {
						hazardToSpawn = UnityEngine.Random.Range (2, 4);
					}
					if (PlayerPrefs.GetInt ("Initalize Basketball") == 1 && PlayerPrefs.GetInt ("Initalize Soccer") == 3) {
						hazardToSpawn = UnityEngine.Random.Range (4, 6);
					}
					if (PlayerPrefs.GetInt ("Initalize Basketball") == 2 && PlayerPrefs.GetInt ("Initalize Soccer") == 1) {
						hazardToSpawn = UnityEngine.Random.Range (6, 8);
					}
					if (PlayerPrefs.GetInt ("Initalize Basketball") == 2 && PlayerPrefs.GetInt ("Initalize Soccer") == 2) {
						hazardToSpawn = UnityEngine.Random.Range (8, 10);
					}
					if (PlayerPrefs.GetInt ("Initalize Basketball") == 2 && PlayerPrefs.GetInt ("Initalize Soccer") == 3) {
						hazardToSpawn = UnityEngine.Random.Range (10, 12);
					}
					if (PlayerPrefs.GetInt ("Initalize Basketball") == 3 && PlayerPrefs.GetInt ("Initalize Soccer") == 1) {
						hazardToSpawn = UnityEngine.Random.Range (12, 14);
					}
					if (PlayerPrefs.GetInt ("Initalize Basketball") == 3 && PlayerPrefs.GetInt ("Initalize Soccer") == 2) {
						hazardToSpawn = UnityEngine.Random.Range (14, 16);
					}
					if (PlayerPrefs.GetInt ("Initalize Basketball") == 3 && PlayerPrefs.GetInt ("Initalize Soccer") == 3) {
						hazardToSpawn = UnityEngine.Random.Range (16, 18);
					}
				}
			}
			Instantiate (hazards [hazardToSpawn], spawnPos, Quaternion.identity);
			count++;
		}
	}
}
