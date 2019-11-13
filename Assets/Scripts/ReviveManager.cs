using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviveManager : MonoBehaviour {
	public int revs;
	private int count = 1;
	public Image[] images;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	revs = GameObject.Find("healthsystem").GetComponent<healthsystem>().lives;
	count = 1;
		foreach(Transform child in transform)
		{
			if (count <= revs){
				count++;
		    child.gameObject.GetComponent<FadeOut>().on = true;
			}
			else{
				child.gameObject.GetComponent<FadeOut>().on = false;
			}
		}
	}
}
