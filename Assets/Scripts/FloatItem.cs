using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatItem : MonoBehaviour {

	public float dist = 0.1f;
	public int radius = 10;
	private int count = 0;
	private int inc = 1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		Vector3 newPos;
		count = count + inc;
		newPos = new Vector3(0,(inc * dist),0);

		if(count == radius){
			inc = -1;
		}
		else if(count == 0){
			inc = 1;
		}

		Vector3 oldPos = transform.position;
		transform.position = newPos + oldPos;
	}
}
