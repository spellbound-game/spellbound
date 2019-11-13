using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2 : MonoBehaviour
{
	public bool sleeping = true;
	public bool charging = false;
	public float initcharger;
	public bool spikes = false;
	public int hitstospikes;
	private int hits = 0;
	public Vector3 start;
	



	void Start()
{
	start = gameObject.transform.position;

}
    // Start is called before the first frame update

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D bullet) {
		
        if (bullet.gameObject.tag == "bullet"){
        	
        	hits += 1;
        	//Debug.Log(hits + "hits");
        	if (charging){
        		gameObject.GetComponent<boss2charge>().chargetimer = initcharger;;
        	}
        	if (sleeping){
        		sleeping = false;
        		charging = true;
        	}
        
        	
        }}
    void onCollisonEnter2D(Collision2D player){
    	if(player.gameObject.tag == "Player"){
    		if (sleeping){
    			sleeping = false;
    			charging = true;
    		}
    		
    	}
    }
    void Update()
    {
    	
    	initcharger = gameObject.GetComponent<boss2charge>().initchargetimer;
		if (hits >= hitstospikes){
			sleeping = false;
			charging = false;
			hits = 0;
			gameObject.transform.position = start + new Vector3 (10f, 0f, 0f);
			spikes =  true;
			
		}
        
    }}
