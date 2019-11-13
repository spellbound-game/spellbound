using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileAuto : MonoBehaviour {
	public Transform firePoint;
	public GameObject spellPrefab;
	public int freq = 300;
	public int counter = 0;
	public bool go;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		go = GameObject.Find("projectile_out").GetComponent<targetPlayer>().cycle1;
		if(go){
			if(counter > freq){
				Instantiate(spellPrefab, firePoint.position, firePoint.rotation);
				counter = 0;
			}
			else{
				counter++;
			}}
	}
}
