using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_spawn : MonoBehaviour {

	// Use this for initialization
	private bool spawn = false;
	public GameObject monster;
	public float timer;
	private float initial;
	public Transform spawnpoint;
	// Update is called once per frame
	void Start(){

		initial = timer;
		
	}
	void OnTriggerStay2D(Collider2D player){
		if (player.gameObject.tag == "Player"){
			spawn = true;
		}else{spawn = false;}
	}/*
	void OnTriggerExit2D(Collider2D player){
		if (player.gameObject.tag == "Player"){
			spawn = false;
		}
	}*/

	void generate ()
    {
        // shooting logic
        Instantiate(monster, spawnpoint.position, spawnpoint.rotation);
    }

	void Update () {
		//Debug.Log(initial);
		//Debug.Log(spawn);
		timer -= Time.deltaTime;
     	if (spawn && timer <= 1f){
     		generate();
     		timer = initial;

     	}
		

		}
		
	
}
