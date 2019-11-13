using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_noplayer : MonoBehaviour {
	public float speed;
	private int playeron =0;
	public float routeDistance;
	private float traveled = 0;
	private float initial = 0;
	public bool faceLeft = true;
	private float velocity = 0f;
	public Transform groundDetection;


	// Update is called once per frame
	void Update () {
		if(faceLeft == true){
			velocity = speed * -1f;
		}else{
			velocity = speed;
		}
		transform.Translate(Vector2.left * velocity * Time.deltaTime);
		if (speed >0){
		traveled++;}
		if(traveled > routeDistance) {
			if(faceLeft == true){
				faceLeft = false;
				traveled = 0;
			}	else{
				faceLeft = true;
				traveled = 0;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D other) {
         if (other.gameObject.tag == "Player") {
             if (speed != 0) {
             	initial = speed;
             	}
             speed = speed*0;
             playeron = playeron +1;
         }
     }

	private void OnCollisionExit2D(Collision2D other) {
	   if (other.gameObject.tag == "Player") {
	   	   playeron = playeron - 1;
	   	   if (playeron == 0){
	       speed = initial;
	       }
	   }
	}
}
