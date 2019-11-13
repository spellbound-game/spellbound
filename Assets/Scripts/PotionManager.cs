using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour {
	public int mana;
	private int count = 1;
	public Image[] images;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	mana = GameObject.Find("healthsystem").GetComponent<healthsystem>().potions;
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
