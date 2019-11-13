using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolAI : MonoBehaviour {
	public float speed;
	public float distance;
	
	private bool faceLeft = true;
	
	public Transform groundDetection;

	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * speed * Time.deltaTime);
		RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
		if(groundInfo.collider == false) {
			if(faceLeft == true){
				transform.eulerAngles = new Vector3(0, -180, 0);
				faceLeft = false;
			}	else{
				transform.eulerAngles = new Vector3(0, 0, 0);
				faceLeft = true;
			}
		}
	}
	void OnTriggerEnter2D (Collider2D thing){
		RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
		if(thing.gameObject.tag != "ignore"&& thing.gameObject.tag != "Respawn" && thing.gameObject.tag != "collectable"){
		if(groundInfo.collider == true) {
			if(faceLeft == true){
				transform.eulerAngles = new Vector3(0, -180, 0);
				faceLeft = false;
			}	else{
				transform.eulerAngles = new Vector3(0, 0, 0);
				faceLeft = true;
			}
		}
	}}
}
