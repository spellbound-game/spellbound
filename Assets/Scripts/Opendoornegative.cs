using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opendoornegative : MonoBehaviour{
	Animator anim;
	public Collider2D doorCol;
	public GameObject connectedPad;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		doorCol= GetComponent<Collider2D>();
		
	}

	// Update is called once per frame
	void Update () {
		pad triggerScript = connectedPad.GetComponent<pad>();
		if (triggerScript.pressed == true){
			doorCol.enabled = true;
			anim.SetBool("IsOpen", false);
		}
		else{
			doorCol.enabled = false;
			anim.SetBool("IsOpen", true);
		}
	}
}
