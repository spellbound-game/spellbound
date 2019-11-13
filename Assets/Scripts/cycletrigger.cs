using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cycletrigger : MonoBehaviour {

	Animator anim;
	public Collider2D doorCol;
	//public GameObject connectedPad;
	public float timer;
	public bool open = false;
	private float count;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		
	}

	// Update is called once per frame
	void Update () {
		count = count + Time.deltaTime;
		if (count > timer){
			open = !open;
			count = 0;
		}
		
		if (open == true){
			doorCol.enabled = false;
			anim.SetBool("IsOpen", true);
		}
		else{
			doorCol.enabled = true;
			anim.SetBool("IsOpen", false);
		}
	}
}
