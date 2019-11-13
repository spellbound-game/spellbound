using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerdeathrev1 : MonoBehaviour {
	public Transform rezpoint;
	public GameObject whichplayer;
	public string whichkey;
	private bool canrez = false;
	private int livesleft;
	// Use this for initialization

	// Update is called once per frame

	void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.tag == "Respawn") {
        	//Debug.Log("Grab now true");
            
            	canrez = true;}


            	
       
            
          
        }

    void OnTriggerExit2D(Collider2D other) {
         if (other.gameObject.tag == "Respawn") {
        	//Debug.Log("Grab now false");
            
            	canrez = false;}
            	}
	void Update () {
		//Debug.Log(whichplayer + " is" + whichplayer.gameObject.active);
		livesleft = GameObject.Find("healthsystem").GetComponent<healthsystem>().lives;
		if (Input.GetButtonDown(whichkey)){
				if (whichplayer.gameObject.activeSelf == false && canrez && livesleft > 0){
					//Debug.Log("Pressed");
					revive();
				}
			

		}
		
	}
	void revive(){
		GameObject.Find("healthsystem").GetComponent<healthsystem>().lives -= 1;;
		whichplayer.gameObject.SetActive(true);
		//whichplayer.gameObject.GetComponent<Renderer>().enabled= true;
		//gameObject.GetComponent<Collider2D>().enabled = true;
		whichplayer.transform.position = rezpoint.position;
		

		//Instantiate(whichplayer, rezpoint.position, rezpoint.rotation);

	}
}
