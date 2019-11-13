using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3_fire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject right;
    public GameObject left;
    public GameObject down;
    public GameObject DL;
    public GameObject DR;
    public bool fire;
    public float timer =  6;
    private float start = 0;
    public Transform target1;
   

    // Update is called once per frame
    
    void Update()
    {
    	fire= GetComponent<boss3_control>().fire;

    	if (fire){

    		




	    	start += Time.deltaTime;
	    	if (start > timer){
	    		Instantiate(right, gameObject.transform.position, gameObject.transform.rotation);
	    		Instantiate(left, gameObject.transform.position, gameObject.transform.rotation);
	    		Instantiate(down, gameObject.transform.position, gameObject.transform.rotation);
	    		Instantiate(DL, target1.position,Quaternion.Euler(45,45,0));
	    		Instantiate(DR, target1.position,Quaternion.Euler(-45,45,0));
	    		Instantiate(DR, target1.position,Quaternion.Euler(-45,-45,0));
	    		Instantiate(DR, target1.position,Quaternion.Euler(45,-45,0));
	    		
	    		start = 0;}}}}
