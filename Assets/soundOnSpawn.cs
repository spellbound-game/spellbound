using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundOnSpawn : MonoBehaviour {
	public AudioClip impact;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GameObject.Find("AudioController").GetComponent<AudioSource>();
		audioSource.PlayOneShot(impact, 0.1F);
	}

	// Update is called once per frame
	void Update () {

	}
}
