using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteManager : MonoBehaviour {

	public Text display_text;
	public GameObject continue_button;
	public GameObject menu_button;

	public AudioClip score_tick;
	public AudioClip button_sound;
  	AudioSource audioSource;


	private int target_score = 0;
	private int time_score;
	private int current_score = 0;
	//private int wait = 50;
	private int count = 0;


	// Use this for initialization
	void Start () {
		audioSource = GameObject.Find("AudioController").GetComponent<AudioSource>();
		target_score = GameObject.Find("healthsystem").GetComponent<healthsystem>().score;
		time_score = 300 - Mathf.RoundToInt(GameObject.Find("Time").GetComponent<TimeManager>().time);
		continue_button.GetComponent<Button>().interactable = false;
		menu_button.GetComponent<Button>().interactable = false;
		
	}

	// Update is called once per frame
	void Update () {

		if (count > 50)
		{
			if (current_score + 50 < target_score)
			{
				current_score += 10;
				audioSource.PlayOneShot(score_tick, 0.05F);
			}
			else if (current_score < target_score)
			{
				current_score += 1;
				audioSource.PlayOneShot(score_tick, 0.05F);
			}
		}
		if (count == 200)
		{
			if (time_score > 0)
			{
					target_score += time_score;
			}
		}
		if (count == 400)
		{
			GameObject.Find("healthsystem").GetComponent<healthsystem>().score = target_score;
			audioSource.PlayOneShot(button_sound, 0.2F);
			continue_button.GetComponent<Button>().interactable = true;
			menu_button.GetComponent<Button>().interactable = true;
		}
		if (count < 200)
		{
				display_text.text = ( "score: " + current_score.ToString() );
		}
		else if (count < 350)
		{
				display_text.text = ( "score: " + current_score.ToString() + "\n (Time Bonus + " + time_score.ToString() + ")");
		}
		else
		{
				display_text.text = ( "score: " + current_score.ToString() );
		}

		count++;
	}
}
