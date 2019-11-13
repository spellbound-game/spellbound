using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_key : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Rkey_activated;
    public bool Bkey_activated;

    public GameObject Bkey;
    public GameObject Rkey;
    public GameObject portal;



    // Update is called once per frame
    void start(){
    	Bkey.SetActive(false);
    	Rkey.SetActive(false);
    	portal.SetActive(false);
    }
    void Update()
    {
       if( Rkey_activated && Bkey_activated ){
       	portal.SetActive(true);
       } 
    }

    void OnTriggerEnter2D(Collider2D player){
    	if (player.gameObject.tag == "Player"){
    		if (player.GetComponent<Key>().has_key == true){
    			player.GetComponent<Key>().has_key = false;;
    			if (player.name.Substring(6) == "1"){
    				Rkey_activated = true;
    				Rkey.SetActive(true);
    			}else if(player.name.Substring(6) == "2"){
    				Bkey_activated= true;
    				Bkey.SetActive (true);
    			}
    		}
    	}

    }
}
