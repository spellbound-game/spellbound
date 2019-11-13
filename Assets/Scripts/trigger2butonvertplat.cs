using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger2butonvertplat : MonoBehaviour {

	// Use this for initialization
public float speed;
	public float routeDistance;
	private float traveled = 0;

	public GameObject trigger1;
	public GameObject trigger2;
	public bool on1 = false;
	public bool on2 = false;
	//private bool move = true;



	//public bool faceLeft = true;
	private float velocity = 0f;
	public Transform groundDetection;


	// Update is called once per frame
	void Update () {
		pad triggerScript1 = trigger1.GetComponent<pad>();
		on1 = triggerScript1.pressed;
		pad triggerScript2 = trigger2.GetComponent<pad>();
		on2 = triggerScript2.pressed;
		
		
		if(on1 | on2 ){
				velocity = speed;
			
			transform.Translate(Vector2.up * velocity * Time.deltaTime);
			traveled++;}
			//Debug.Log(traveled);
		if(traveled > routeDistance) {
			//Debug.Log("end");
			//if(faceLeft == true){
				//faceLeft = false;
			on1 = false;
			on2 = false;
			

				
			}
		
		if (!on1 && !on2){
			if (traveled != 0){
			velocity = -1*speed;
			transform.Translate(Vector2.up * velocity * Time.deltaTime);
			traveled--;
		}
		}}
	
	void OnCollisionEnter2D(Collision2D other) {

         if (other.gameObject.tag == "Player" || other.gameObject.tag == "Item" ) {
             other.transform.parent = transform;
         }
     }

	private void OnCollisionExit2D(Collision2D other) {
	   if (other.gameObject.tag == "Player" || other.gameObject.tag == "Item") {
	       other.transform.parent = null;
	   }
	}
}

