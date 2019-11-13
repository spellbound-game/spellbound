using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arenamana : MonoBehaviour{

	public int	mana;
	private int count = 1;
	public Image[] images;
	public bool isplayer1;
	public GameObject player;

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
		if (isplayer1){
			mana = GameObject.Find("healthsystem").GetComponent<arenamanasys>().potions1;
		}
		if (!isplayer1){
			mana = GameObject.Find("healthsystem").GetComponent<arenamanasys>().potions2;
		}
		count = 1;
		foreach(Transform child in transform)
		{
			if (count <= mana){
				count++;
		    child.gameObject.GetComponent<FadeOut>().on = true;
			}
			else{
				child.gameObject.GetComponent<FadeOut>().on = false;
			}
		}
	}
}
