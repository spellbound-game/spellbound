using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2sleep : MonoBehaviour
{
    public bool sleeping;
    public int current;
    public int inthealth;
    public float regenrate;
    public float regenrateinit;


    // Update is called once per frame

    void Update()
    {
    	sleeping = gameObject.GetComponent<boss2>().sleeping;
    	current = gameObject.GetComponent<hit_to_death>().hits_current;
    	inthealth = gameObject.GetComponent<hit_to_death>().hits_initial;

    	if (sleeping){
    		gameObject.GetComponent<boss2>().charging = false ;;
    		if (current < inthealth){
    			regenrate-=Time.deltaTime;
    			if (regenrate < 0){
    				gameObject.GetComponent<hit_to_death>().hits_current += 1 ;;
    				regenrate = regenrateinit;
    			}

    		}


    	}
        
    } 
}
