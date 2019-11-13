using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public Text scoreText;

	public float time = 0f;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		scoreText.text = time.ToString("F2");
	}
}
