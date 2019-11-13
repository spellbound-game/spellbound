using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour {
	public int health;
	private float count = 0;
	public GameObject prefab;
	public GameObject self;
	// Use this for initialization
	void OnCollisionEnter2D(Collision2D Hazard) {
		//Debug.Log(count);
		//Debug.Log("i " + gameObject.name +" hit by "+ Hazard.gameObject.tag);
        if (Hazard.gameObject.tag == "Hazard" || Hazard.gameObject.tag == "Monster" ) {
        	//Debug.Log(count);
            count = count +1;

            if(health <= count){
			//gameObject.GetComponent<Renderer>().enabled = false;
						Instantiate(prefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
			//gameObject.GetComponent<Collider2D>().enabled = false;
			}}}
	void OnTriggerEnter2D(Collider2D Hazard) {
		//Debug.Log(count);
		//Debug.Log("i " + gameObject.name +" hit by "+ Hazard.gameObject.tag);
        if (Hazard.gameObject.tag == "Hazard") {
        	//Debug.Log(self.name + " " + Hazard.gameObject.name);
        	if ((self.name == "player1" && Hazard.gameObject.name == "target_p2(Clone)") || (self.name == "player2" && Hazard.gameObject.name == "target_p1(Clone)")){
        		//Debug.Log ("helo there");
        	}

        	else{
        	//Debug.Log(count);
	            count = count +1;

	            if(health <= count){
				//gameObject.GetComponent<Renderer>().enabled = false;
							Instantiate(prefab, transform.position, transform.rotation);
	            gameObject.SetActive(false);
				//gameObject.GetComponent<Collider2D>().enabled = false;
				}}
		/*if (Hazard.gameObject.tag == "Monster") {
        	Debug.Log(count);
            count = count +1;
			other.GetComponent<Renderer>().enabled = false;
            if(health <= count){
			Destroy(gameObject);
			}

         }*/
     }

}}
