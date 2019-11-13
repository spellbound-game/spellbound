using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2charge : MonoBehaviour{
	public float speed;
	public float distance;
	
	private bool faceLeft = true;
	
	public Transform groundDetection;
	public bool charging;
	public float chargetimer;
	public float initchargetimer;
	
	// Update is called once per frame
	void Update () {


		charging = gameObject.GetComponent<boss2>().charging;
		if (charging){
			gameObject.GetComponent<boss2>().sleeping = false ;;
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
			chargetimer -= Time.deltaTime;
			if (chargetimer < 0){
				gameObject.GetComponent<boss2>().sleeping = true ;;
				chargetimer = initchargetimer;
			}
		}
}
	void OnTriggerEnter2D (Collider2D thing){
		RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
		if(thing.gameObject.tag != "ignore"&& thing.gameObject.tag != "Respawn" && thing.gameObject.tag != "bullet"){
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