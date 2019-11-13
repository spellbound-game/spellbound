using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_crate : MonoBehaviour
{
	public bool isbreak;
	//public Animator m_Animator;
	public GameObject create_poof;
	//public bool anim = false;
	
	
	void OnTriggerEnter2D(Collider2D bullet){
		if (bullet.gameObject.name == "arena_spell(Clone)" || bullet.gameObject.name == "Spell_obj_p1(Clone)"){
			isbreak = true;
			Instantiate(create_poof, gameObject.transform.position, gameObject.transform.rotation);
			//anim = true;
            gameObject.SetActive(false);
		}
	}
 	void OnCollisionEnter2D(Collision2D player)
    {
       

        if (player.gameObject.tag == "Hazard" ){
           Instantiate(create_poof, gameObject.transform.position, gameObject.transform.rotation);
           isbreak = true;
           //anim = true;
           gameObject.SetActive(false);


    }}}


