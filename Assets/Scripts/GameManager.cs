using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public bool gameOver;
	public static GameManager instance;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startGame () {
		UiManager.instance.GameStart();
		ScoreManager.instance.startScore();
		GameObject.Find ("PlatformSpawner").GetComponent<PlatformSpawner> ().startSpawningPlatforms ();
	}

	public void GameOver () {
		UiManager.instance.GameOver();
		ScoreManager.instance.stopScore();
		gameOver = true;
	}
}
