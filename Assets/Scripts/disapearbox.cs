using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disapearbox : MonoBehaviour
{
	
	public bool disapear;

    
	
 void OnCollisionEnter2D(Collision2D player)
    {
        //Debug.Log("I hit " + enemy.gameObject.tag );

        if (player.gameObject.tag == "Player"){
           disapear = true;
           

    }}}