using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    private Text text;
    private int score = 0;

    private void Awake() {
        text = GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var currentScore = GameStatus.GetScore();
        if (currentScore > score) {
            score += (currentScore - score) / 30 + 1;
            if (score > currentScore) score = currentScore;
        }
        text.text = score.ToString("D10");
    }
}