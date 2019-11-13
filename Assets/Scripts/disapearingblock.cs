using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disapearingblock : MonoBehaviour
{
	public bool disapear;
	public float stalltimer;
	public float returntimer;
	private float count = 0;
	public GameObject box;
    private Animator anim;
    public GameObject prefab;

    void Start(){
        anim = gameObject.GetComponent<Animator>();
    }
    void Update(){
    	disapear = box.GetComponent<disapearbox>().disapear;
    	if (disapear){
            //Instantiate(prefab, transform.position + new Vector3(1f,1f,0f), transform.rotation);
            anim.SetBool("fade",true);
            
    		count += Time.deltaTime;
    		if (count >  stalltimer){
    			box.SetActive(false);
                anim.SetBool("fade",false);
    		}
    		if (count > returntimer){
    			count = 0;
    			box.SetActive(true);
    			box.GetComponent<disapearbox>().disapear = false ;;
                
    		}


    	}
    }}
