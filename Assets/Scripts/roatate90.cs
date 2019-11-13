using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roatate90 : MonoBehaviour {

	// Use this for initialization
	public int degrees;
	void Start () {
		RotateLeft();
	}
	
	// Update is called once per frame
 	void RotateLeft () {
    	transform.Rotate (Vector3.forward * -degrees);
	 }}