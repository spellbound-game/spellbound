using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour {
	public bool isGrabable = false;

	public bool Grabbed = false;
	public bool hit = false;


void OnTriggerEnter2D(Collider2D surface){
	if (surface.gameObject.tag != "ignore" && surface.gameObject.tag != "Respawn" && surface.gameObject.tag != "collectable"){
			hit = true;
	
	}
			
		
}


}