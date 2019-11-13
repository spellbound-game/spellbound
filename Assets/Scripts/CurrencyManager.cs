using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour {
    public Text scoreText;
    private int target_score;
    // Use this for initialization
    void Start () {
        target_score = GameObject.Find("healthsystem").GetComponent<healthsystem>().currency;
    }
	
	// Update is called once per frame
	void Update () {
        target_score = GameObject.Find("healthsystem").GetComponent<healthsystem>().currency;
        scoreText.text = target_score.ToString();
    }
}
