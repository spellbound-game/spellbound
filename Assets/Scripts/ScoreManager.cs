using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;

    private int target_score;
    private int current_display_score;

	// Use this for initialization
	void Start () {
        target_score = GameObject.Find("healthsystem").GetComponent<healthsystem>().score;
        current_display_score = target_score;
    }

	// Update is called once per frame
	void Update () {
        target_score = GameObject.Find("healthsystem").GetComponent<healthsystem>().score;
        if (target_score > current_display_score){
            current_display_score++;
        }
        else if (target_score < current_display_score)
        {
            current_display_score--;
        }
        scoreText.text = current_display_score.ToString();
    }
}
