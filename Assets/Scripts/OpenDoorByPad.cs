using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorByPad : MonoBehaviour {
	Animator anim;
	public Collider2D doorCol;
	public GameObject connectedPad;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		
	}

	// Update is called once per frame
	void Update () {
		pad triggerScript = connectedPad.GetComponent<pad>();
		if (triggerScript.pressed == true){
			doorCol.enabled = false;
			anim.SetBool("IsOpen", true);
		}
		else{
			doorCol.enabled = true;
			anim.SetBool("IsOpen", false);
		}
	}
}
