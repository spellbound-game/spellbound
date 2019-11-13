using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat : MonoBehaviour
{
	// Use this for initialization
public float speed;
	public GameObject end;
	private Vector3 start;
	//private float traveled = 0;

	//public GameObject trigger2;

	//public bool on2 = false;
	private float distance;
	private float distancefromstart;
	//private bool move = true;
	private bool away = true;


	//public bool faceLeft = true;
	
	//public Transform groundDetection;

	void Start(){
		start = gameObject.transform.position;
		distance = Vector3.Distance(start, end.transform.position);
		//Debug.Log(distance);
		//float init = speed;
	}
	// Update is called once per frame
	void Update () {
		//pad triggerScript1 = trigger1.GetComponent<pad>();
		//on1 = triggerScript1.pressed;
		

		distancefromstart = Vector3.Distance(start, gameObject.transform.position);
		
		if (away){
			if (distancefromstart>= distance)
			{

			away = false;

			}
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, end.transform.position, step);
		}
		else{
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, start, step);
			if (distancefromstart < .25){
				away = true;
			}
		}
				
				
				
				
			}
	
		
	
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
