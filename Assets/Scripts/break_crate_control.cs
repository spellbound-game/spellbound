using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_crate_control : MonoBehaviour
{
	public bool isbreak;
	public float stalltimer;
	public float returntimer;
	private float count = 0;
	public GameObject box;
	private Vector3 startpos;
	public GameObject return_crate;
	private bool isanim ;


    void Start(){
    	startpos = gameObject.transform.position;

    }
    void Update(){
    	isbreak = box.GetComponent<Break_crate>().isbreak;
    	//anim = box.GetComponent<Break_crate>().anim;
    	//GameObject check = 
    	if (isbreak){

    		count += Time.deltaTime;
    		
    		box.SetActive(false);
    		
    		if (!isanim && count > returntimer/2){
    			Instantiate(return_crate, gameObject.transform.position, gameObject.transform.rotation);
    			isanim = true;
    		}
    		if (count > returntimer){
    			count = 0;
    			box.transform.position = startpos;
    			box.SetActive(true);
    			box.GetComponent<Break_crate>().isbreak = false ;;
    			isanim = false;
    		}


    	}
    }}