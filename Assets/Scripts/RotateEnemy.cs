using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemy : MonoBehaviour {
	public GameObject	 target;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (target.transform.position.x < transform.position.x){
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		else{
			transform.eulerAngles = new Vector3(-180, 0, -180);
		}
	}
}
