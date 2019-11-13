using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glob : MonoBehaviour
{
	public GameObject globto;
	private GameObject globcheck;
	private Vector3 position;
	private bool globb = false;
	//private Vector3 globpoint;
    // Start is called before the first frame update


    // Update is called once per frame
    void OnTriggerExit2D(Collider2D other){
    	//Debug.Log("hey");
    	globcheck = other.gameObject.GetComponent<glob>().globto;
    	if (globcheck.gameObject.name == globto.gameObject.name){
    		other.gameObject.SetActive(false);
    		gameObject.SetActive(false);
    		globb = true;
    		if (globb){
    		Instantiate(globto, position, gameObject.transform.rotation);
    		globb = false;}
    		

    		
    		
    		
    	}

    }
    void Update()
    {
    	position = gameObject.transform.position+ new Vector3(0f,2f,0f);
    	
    }
}
