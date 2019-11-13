using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public float speed;

	public float routeDistance;
	public bool on = true;
	private float traveled = 0;

	public bool faceLeft = true;
	private float velocity = 0f;
	public Transform groundDetection;


	// Update is called once per frame
	void Update () {
		if(on==true){
			if(faceLeft == true){
				velocity = speed * -1f;
			}else{
				velocity = speed;
			}
			transform.Translate(Vector2.left * velocity * Time.deltaTime);
			traveled++;
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
	}
	void OnCollisionEnter2D(Collision2D other) {
         if (other.transform.tag == "Player") {
             other.transform.parent = transform;
         }
     }

	private void OnCollisionExit2D(Collision2D other) {
	   if (other.transform.tag == "Player") {
	       other.transform.parent = null;
	   }
	}
}
