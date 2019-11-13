using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayhealth : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		playerhealth cs = player.GetComponent<playerhealth>();
		int health = cs.health + 1;
		Debug.Log(health);

		Transform[] allChildren = GetComponentsInChildren<Transform>();
			foreach (Transform child in allChildren)
			{
				if (health > 0)
				{
					child.gameObject.SetActive(true);
					health--;
				}
				else{
					child.gameObject.SetActive(false);
				}
			}
	}
}
