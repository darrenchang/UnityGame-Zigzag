﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	public static UiManager instance;

	public GameObject zigzagPanel;
	public GameObject gameOverPanel;
	public GameObject tapText;
	public Text score;
	public Text highScore1;
	public Text highScore2;
	public Text currentScore;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		highScore1.text = "High score: " + PlayerPrefs.GetInt ("highScore").ToString();
	}

	public void GameStart() {
		tapText.SetActive (false);
		zigzagPanel.GetComponent<Animator> ().Play ("panelUp");
	}

	public void GameOver() {
		score.text = PlayerPrefs.GetInt ("score").ToString();
		highScore2.text = PlayerPrefs.GetInt ("highScore").ToString();
		gameOverPanel.SetActive (true);
	}

	public void Reset() {
		//gameOverPanel.GetComponent<Animator> ().Play("gameOverPanelDisappear");
		SceneManager.LoadScene (0);
	}

	// Update is called once per frame
	void Update () {
		if (!GameObject.Find ("Ball").GetComponent<BallController> ().gameOver &&
			PlayerPrefs.GetInt ("score") != 0) {
			currentScore.text = PlayerPrefs.GetInt ("score").ToString ();
		} else {
			currentScore.text = "";
		}
	}
}
