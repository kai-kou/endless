using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	int score = 0;
	GameObject scoreText;

	public void AddScore(int score){
		this.score += score;
	}

	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find ("Score");
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.GetComponent<Text> ().text = "Score:" + score;
	}
}
