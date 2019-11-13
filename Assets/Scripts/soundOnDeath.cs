using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundOnDeath : MonoBehaviour {
	// Use this for initialization
	public AudioClip impact;
  AudioSource audioSource;

	private bool use = false;

	void Start () {
		audioSource = GameObject.Find("AudioController").GetComponent<AudioSource>();
	}
		
	void OnTriggerEnter2D(Collider2D other) {
		if (use == false)
		{
			if (other.gameObject.tag == "Player")
			{
				audioSource.PlayOneShot(impact, 0.1F);
				use = true;
			}
		}

	}

	// Update is called once per frame
	//void OnDisable(){
		//audioSource.PlayOneShot(impact, 0.1F);
		//use = true;

	//}
}
