using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerhorizontal : MonoBehaviour{
	public float speed;
	public float routeDistance;
	private float traveled = 0;

	public GameObject trigger;
	public bool on = false;
	//private bool move = true;



	//public bool faceLeft = true;
	private float velocity = 0f;
	public Transform groundDetection;


	// Update is called once per frame
	void Update () {
		pad triggerScript = trigger.GetComponent<pad>();
		on = triggerScript.pressed;
		
		
		if(on==true ){
				velocity = speed;
			
			transform.Translate(Vector2.right * velocity * Time.deltaTime);
			traveled++;}
			//Debug.Log(traveled);
		if(traveled > routeDistance) {
			//Debug.Log("end");
			//if(faceLeft == true){
				//faceLeft = false;
			on = false;
			

				
			}
		
		if (on == false ){
			if (traveled != 0){
			velocity = -1*speed;
			transform.Translate(Vector2.right * velocity * Time.deltaTime);
			traveled--;
		}
		}}
	
	void OnCollisionEnter2D(Collision2D other) {

         if (other.gameObject.tag == "Player") {
             other.transform.parent = transform;
         }
     }

	private void OnCollisionExit2D(Collision2D other) {
	   if (other.gameObject.tag == "Player") {
	       other.transform.parent = null;
	   }
	}
}
