using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour{
	public bool grab;
	public Transform holdpoint;
	public bool grabbing = false;
	public bool canhold =false;
	private GameObject item;
	public GameObject self;
	public bool facingright;
	private bool dir_grab;
	public Transform holdpoint2;
	// Update is called once per frame
    void Start(){
        //Debug.Log(GameObject.FindGameObjectsWithTag("Item").Length);
        if(GameObject.FindGameObjectsWithTag("Item").Length > 0){
            item = GameObject.FindGameObjectsWithTag("Item")[0];
            }else{
                item = gameObject;
            }
    }

	void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.tag == "Item"){


                if (!grabbing){
        		other.gameObject.GetComponent<GrabItem>().isGrabable = true;
            	canhold = true;
            	item = other.gameObject;

            }}}
    void OnTriggerExit2D(Collider2D other) {
         if (other.gameObject.tag == "Item") {
            if (!grabbing){
		        other.gameObject.GetComponent<GrabItem>().isGrabable = false;
                canhold = false;
                //item = other.gameObject;

            }else{canhold= false;}}


        }
    void OnDisable(){
        grabbing = false;
        canhold = false;
        //item.gameObject.GetComponent<GrabItem>().isGrabable = false;;
    }
    /*private void OnTriggerExit2D(Collider2D other) {
	   if (other.gameObject.tag == "Item") {
        	Debug.Log("Grab now false");

            grab = false;
        }}*/
    void Update(){
        if (item.activeSelf == false){
            canhold=false;
            item.GetComponent<GrabItem>().isGrabable = false;
        }
    	facingright = self.GetComponent<CharacterController2D>().m_FacingRight;
    	
        //Where the box is 
    	if (grabbing){
            if (item.activeSelf  == false){
                item.GetComponent<GrabItem>().Grabbed = false;;
                grabbing = false;
            }

            if ( item.GetComponent<GrabItem>().hit || item.activeInHierarchy == false){
                grabbing = false;
                item.GetComponent<GrabItem>().Grabbed = false;;
                item.GetComponent<GrabItem>().hit = false;;
            }
    		if (facingright == dir_grab){
    			item.transform.position = holdpoint.position;
    		}else{item.transform.position = holdpoint2.position;
    		}
    	}
    	
       
        //Which button
    	if (self.name == "player1" || self.name == "playerArena1"){
    		if (canhold){
                /*
    			if (item.GetComponent<GrabItem>().hit && grabbing){
		    		grabbing = false;
		    		item.GetComponent<GrabItem>().Grabbed = false;;
		    		item.GetComponent<GrabItem>().hit = false;;
		    		

		    	}
                */
	        	if (Input.GetButtonDown("grab1")){
	            	grabbing = true;
					item.GetComponent<GrabItem>().Grabbed = true;;
					item.GetComponent<GrabItem>().hit =false;;
					dir_grab = facingright;

				}
        	}
    		
    		

            if (Input.GetButtonUp("grab1")){
                grabbing = false;
				item.GetComponent<GrabItem>().Grabbed = false;;
			}
		}
		if (self.name == "player2" || self.name == "playerArena2"){
    		if (canhold){
    			/*
                if (item.GetComponent<GrabItem>().hit && grabbing){
                    grabbing = false;
                    item.GetComponent<GrabItem>().Grabbed = false;;
                    item.GetComponent<GrabItem>().hit = false;;
                    

                }
                */
	        	if (Input.GetButtonDown("grab2")){
	            	grabbing = true;
					item.GetComponent<GrabItem>().Grabbed = true;;
					item.GetComponent<GrabItem>().hit =false;;
					dir_grab = facingright;
				}
        	}

            if (Input.GetButtonUp("grab2")){
                grabbing = false;
				item.GetComponent<GrabItem>().Grabbed = false;;
			}
		}



    }


}
