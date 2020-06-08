using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBasketball : MonoBehaviour {
	float velocity = -5f;
	public int count=0;
	public bool canDestroy =false;

	public bool Move = false; 
	public Vector3 tempPosition;

	public GameObject [] hazards;
	private int hazardToSpawn;
	private Vector3 spawnPos = new Vector3 (0, -3.08f,-3.92f);

	public bool isGameDone;

	public ScoreScript ui;
	public TimerScript timeScript;

	void Start(){
		Move = false;
		tempPosition = transform.position;
		isGameDone=false;
		ui = GameObject.FindWithTag("ui").GetComponent<ScoreScript>();
		timeScript = GameObject.FindWithTag("ui").GetComponent<TimerScript>();
	}
	void Update(){
		if (transform.position == spawnPos) {
			if (isGameDone == false) {
				if (SwipeManager.IsSwipingUp () || SwipeManager.IsSwipingUpLeft () || SwipeManager.IsSwipingUpRight () ||
					SwipeManager.IsSwipingRight () || SwipeManager.IsSwipingLeft ()) {
					Move = true;
					ui.IncrementScore (1);
					ui.useBuzzers (false);
					timeScript.IncreaseTime (1);
					timeScript.DecreaseTime (0);
					hazardToSpawn = UnityEngine.Random.Range (0, 2);
					Instantiate (hazards [hazardToSpawn], spawnPos, Quaternion.identity);
					if (PlayerPrefs.HasKey ("Unlock Basketball 3")) {
						
					} else {
						PlayerPrefs.SetInt ("Unlock Basketball 3", 0);
					}
					PlayerPrefs.SetInt("Unlock Basketball 3", (PlayerPrefs.GetInt("Unlock Basketball 3") + 1));
				} 
				else if (SwipeManager.IsSwipingDown () || SwipeManager.IsSwipingDownLeft () || SwipeManager.IsSwipingDownRight()) {
					ui.useBuzzers (true);
					timeScript.IncreaseTime (0);
					timeScript.DecreaseTime (1);
				}
			}
		}
			if (Move) {
				tempPosition.y -= velocity * Time.deltaTime;
				if (tempPosition.y >= 3.93f) {
					velocity = 5f;
				} else if (tempPosition.y <= 0) {
					velocity = -9f;
				}
				transform.position = tempPosition;
			Vector3 scale =transform.localScale;
			scale.x -= 0.002f;
			scale.y -= 0.002f;
			transform.localScale = scale;
			}
			if (tempPosition.y > 3.38f) {
				canDestroy = true;
			}
			if (tempPosition.y <= 2.67f && tempPosition.y>=2.30f) {
					count=1;
				if (count == 1 && canDestroy) {
					Move = false;
					Destroy (gameObject);
				}
			}
		} 
}
