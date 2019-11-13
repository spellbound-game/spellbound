using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	private bool is_red_player;
	public bool has_key;
	private GameObject key;
    // Start is called before the first frame update
    void Start()
    {
    	if (gameObject.name == "player1"){
    		is_red_player = true;
    	}else{
    		is_red_player = false;
    	}
        
    }
    void OnCollisionEnter2D(Collision2D other) {
    	if (is_red_player && other.gameObject.name.Substring(0,4) == "Rkey"){
    		has_key = true;
    		key = other.gameObject;
    		other.gameObject.SetActive(false);

    	}
    	if (!is_red_player && other.gameObject.name.Substring(0,4) == "Bkey"){
    		key = other.gameObject;
    		has_key = true;
    		other.gameObject.SetActive(false);

    	}
    }
    //become inactive
    void OnDisable(){
    	if (has_key){
    		has_key = false;
    		key.SetActive(true);
    		key.transform.position = gameObject.transform.position;
    		key = null;
    	}


    }


}
