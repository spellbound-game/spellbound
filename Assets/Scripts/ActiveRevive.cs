using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRevive : MonoBehaviour {

    public Animator animator;

    private ParticleSystem ps;

    public GameObject P1;
    public GameObject P2;

    // Use this for initialization
    void Start () {
        if (GameObject.Find("player1")== null){
            P1=GameObject.Find("revive").GetComponent<ActiveRevive>().P1;
        }else{
            P1 = GameObject.Find("player1");}

       if (GameObject.Find("player2")== null){
            P2=GameObject.Find("revive").GetComponent<ActiveRevive>().P2;
        }else{
            P2 = GameObject.Find("player2");}
        ps = GetComponent<ParticleSystem>();
        ps.enableEmission = false;
    }

	// Update is called once per frame
	void Update () {
        if ((!P1.active)||(!P2.active)){
            animator.SetBool("isActive", true);
            ps.enableEmission = true;
        }
        else
        {
            animator.SetBool("isActive", false);
            ps.enableEmission = false;
        }
        

	}
}
