using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetPlayer : MonoBehaviour {
	public Transform target;
	public Transform target1;
	public Transform target2;
	public int hits;
	public bool cycle1 = false;
	public bool cycle2 = false;
	public GameObject fire1;
	public GameObject fire2;
	public GameObject fire3;
	public GameObject cycle2firepoint;
	public float cycle2time;
	public float cycle2firetime = .5f;
	public float brreak;
	private float resetbreak;
	private float reset;
	private int pick;


	// Use this for initialization
	void Start () {
		Vector3 playerPos = new Vector3(target.transform.position.x, 0.0f, 0.0f);

		// Aim bullet in player's direction.
		transform.rotation = Quaternion.LookRotation(playerPos);
		reset = cycle2time;
		pick = Random.Range(0,3);
		resetbreak = brreak;

	}

	// Update is called once per frame
	void Update () {
		hits = GameObject.Find("Basilisk").GetComponent<hit_to_death>().hits_current;

		if (hits== 19){
			cycle2 = true;
			cycle1 = false;
		}
		if(hits == 15){
			cycle2 = true;
			cycle1 = false;
		}
		if(hits == 10){
			cycle2 = true;
			cycle1 = false;
		}
		if(hits == 5){
			cycle2 = true;
			cycle1 = false;
		}
		if(hits == 1){
			cycle2 = true;
			cycle1 = false;
		}


		if(cycle2){
			cycle2time -= Time.deltaTime;
			if (cycle2time > 0){
				cycle2firetime -= Time.deltaTime;
				if (cycle2firetime > 0){
					if (pick == 0){
						Instantiate(fire1, cycle2firepoint.transform.position, cycle2firepoint.transform.rotation );
					}
					if (pick == 1){
						Instantiate(fire2, cycle2firepoint.transform.position, cycle2firepoint.transform.rotation );
					}
					if (pick == 2){
						Instantiate(fire3, cycle2firepoint.transform.position, cycle2firepoint.transform.rotation );
					}}
				else{
					brreak-= Time.deltaTime;
					if (brreak < 0){
						pick = Random.Range(0,3);
						cycle2firetime = .5f;
						brreak = resetbreak;
					}
					}
				}else{
					cycle2 = false;
					cycle2time = reset;
					cycle1 = true;
				}

		}
		// fast rotation
		if (cycle1){
			if (Random.value < .5)
			{
					if (target1 != null){
						target = target1;
					}
					else{
						target = target2;
					}
			}
			else
			{
					if (target2 != null){
						target = target2;
					}
					else{
						target = target1;
					}
			}}

			float rotSpeed = 360f;
			// distance between target and the actual rotating object
			Vector3 D = target.position - transform.position;
			// calculate the Quaternion for the rotation
			Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(D), rotSpeed * Time.deltaTime);
			//Apply the rotation
			transform.rotation = rot;
			// put 0 on the axys you do not want for the rotation object to rotate
			transform.eulerAngles = new Vector3(0,180,-transform.eulerAngles.x);
		
	}
}
