using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button2_1wayplat : MonoBehaviour
{
	// Use this for initialization
public float speed;
	public GameObject end;
	private Vector3 start;
	//private float traveled = 0;

	public GameObject trigger1;
	public GameObject trigger2;
	public bool on1 = false;
	public bool on2 = false;
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
		//Debug.Log(gameObject.name);
		pad triggerScript1 = trigger1.GetComponent<pad>();
		on1 = triggerScript1.pressed;
		pad triggerScript2 = trigger2.GetComponent<pad>();
		on2 = triggerScript2.pressed;

		distancefromstart = Vector3.Distance(start, gameObject.transform.position);
		
		
		if(on1 || on2 )
			{ 	
				//Debug.Log("move");

				if (distancefromstart>= distance)
				{
					//Debug.Log("false");
					float step = 0 * Time.deltaTime;
					transform.position = Vector2.MoveTowards(transform.position, end.transform.position, step);

				}else{
					//Debug.Log("true");
					float step = speed * Time.deltaTime;
					transform.position = Vector2.MoveTowards(transform.position, end.transform.position, step);
				}
				
				
				
				
			}
			//Debug.Log(traveled);
		
		
		if (!on1 && !on2){
			
			{
				float step = speed * Time.deltaTime;
				transform.position = Vector2.MoveTowards(transform.position, start, step);
			
		}
		}}
	
	void OnCollisionEnter2D(Collision2D other) {

         if (other.gameObject.tag == "Player"|| other.gameObject.tag == "Item" ) {
             other.transform.parent = transform;
         }
     }

	private void OnCollisionExit2D(Collision2D other) {
	   if (other.gameObject.tag == "Player" || other.gameObject.tag == "Item" ) {
	       other.transform.parent = null;
	   }
	}
}