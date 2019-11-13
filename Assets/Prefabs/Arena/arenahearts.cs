using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arenahearts : MonoBehaviour{
	private GameObject player;
	public int hearts;
	private int count = 1;
	public Image[] images;
	public bool isplayer1;

	// Use this for initialization
	void Start () {
		if (isplayer1){
			player = GameObject.Find("playerArena1");
		}else{
			player = GameObject.Find("playerArena2");
		}
	}

	// Update is called once per frame
	void Update () {
	hearts = player.GetComponent<ArenaHealth>().health;
	count = 1;
		foreach(Transform child in transform)
		{
			if (count <= hearts){
				count++;
		    child.gameObject.GetComponent<FadeOut>().on = true;
			}
			else{
				child.gameObject.GetComponent<FadeOut>().on = false;
			}
		}
	}
}
