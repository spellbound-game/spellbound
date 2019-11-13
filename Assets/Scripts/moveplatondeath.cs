using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplatondeath : MonoBehaviour{

	public float speed;
	public GameObject end;
	private Vector3 start;
	//private float traveled = 0;

	public GameObject trigger;
	//public GameObject trigger2;
	public bool on1 = false;
	//public bool on2 = false;
	private float distance;
	private float distancefromstart;
	//private bool move = true;



	//public bool faceLeft = true;
	
	public Transform groundDetection;

	void Start(){
		start = gameObject.transform.position;
		distance = Vector3.Distance(start, end.transform.position);
		//Debug.Log(distance);
		//float init = speed;
	}
	// Update is called once per frame
	void Update () {
		if (trigger.gameObject.activeSelf == false){
			on1 = true;

		}
		

		distancefromstart = Vector3.Distance(start, gameObject.transform.position);
		
		
		if(on1)
			{ 	
				if (distancefromstart>= distance)
				{

					float step = 0 * Time.deltaTime;
					transform.position = Vector2.MoveTowards(transform.position, end.transform.position, step);

				}else{
					float step = speed * Time.deltaTime;
					transform.position = Vector2.MoveTowards(transform.position, end.transform.position, step);
				}
				
				
				
				
			}
			//Debug.Log(traveled);
		
		
		if (!on1){
			
			{
				float step = speed * Time.deltaTime;
				transform.position = Vector2.MoveTowards(transform.position, start, step);
			
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
