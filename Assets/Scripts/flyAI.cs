using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyAI : MonoBehaviour {
	public float speed;
	public float routeDistance;
	private float traveled = 0;
	
	private bool faceLeft = true;
	
	public Transform groundDetection;

	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * speed * Time.deltaTime);
		traveled++;
		if(traveled > routeDistance) {
			if(faceLeft == true){
				transform.eulerAngles = new Vector3(0, -180, 0);
				faceLeft = false;
				traveled = 0;
			}	else{
				transform.eulerAngles = new Vector3(0, 0, 0);
				faceLeft = true;
				traveled = 0;
			}
		}
	}
}
