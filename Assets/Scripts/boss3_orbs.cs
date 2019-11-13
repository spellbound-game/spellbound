using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3_orbs : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject orb1;
    public GameObject orb2;
    public bool orbs;
    public float timer =  6;
    private float start = 0;
    private GameObject player1;
    private GameObject player2;
   
    void Start(){
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
    }
    // Update is called once per frame
    
    void Update()
    {
    	orbs = GetComponent<boss3_control>().orbs;
    	if (orbs){

    		




	    	start += Time.deltaTime;
	    	if (start > timer){
                //Debug.Log(player1.activeSelf + "p1");
                //Debug.Log(player2.activeSelf + "p2");
                if (player1.activeSelf == false & player2.activeSelf == true){
                    Debug.Log("1 ran");
                    Instantiate(orb2, gameObject.transform.position + new Vector3(-1f, 2f, 0), gameObject.transform.rotation);
                    Instantiate(orb2, gameObject.transform.position + new Vector3(1f, 2f, 0), gameObject.transform.rotation);
                    Instantiate(orb2, gameObject.transform.position + new Vector3(1f, -2f, 0), gameObject.transform.rotation);
                    Instantiate(orb2, gameObject.transform.position + new Vector3(-1f, -2f, 0), gameObject.transform.rotation);
                    Instantiate(orb2, gameObject.transform.position + new Vector3(2f, 1f, 0), gameObject.transform.rotation);
                    Instantiate(orb2, gameObject.transform.position + new Vector3(2f, -1f, 0), gameObject.transform.rotation);
                    Instantiate(orb2, gameObject.transform.position + new Vector3(-2f, -1f, 0), gameObject.transform.rotation);
                    Instantiate(orb2, gameObject.transform.position + new Vector3(-2f, 1f, 0), gameObject.transform.rotation);
                    start = 0;

                }
                else if (player2.activeSelf == false & player1.activeSelf == true){
                    //Debug.Log("2 ran");
                    Instantiate(orb1, gameObject.transform.position + new Vector3(-1f, 2f, 0), gameObject.transform.rotation);
                    Instantiate(orb1, gameObject.transform.position + new Vector3(1f, 2f, 0), gameObject.transform.rotation);
                    Instantiate(orb1, gameObject.transform.position + new Vector3(1f, -2f, 0), gameObject.transform.rotation);
                    Instantiate(orb1, gameObject.transform.position + new Vector3(-1f, -2f, 0), gameObject.transform.rotation);
                    Instantiate(orb1, gameObject.transform.position + new Vector3(2f, 1f, 0), gameObject.transform.rotation);
                    Instantiate(orb1, gameObject.transform.position + new Vector3(2f, -1f, 0), gameObject.transform.rotation);
                    Instantiate(orb1, gameObject.transform.position + new Vector3(-2f, -1f, 0), gameObject.transform.rotation);
                    Instantiate(orb1, gameObject.transform.position + new Vector3(-2f, 1f, 0), gameObject.transform.rotation);
                    start = 0;
                    
                }
                else if(player2.activeSelf == true & player2.activeSelf == true){
                //Debug.Log("3 ran");
	    		Instantiate(orb1, gameObject.transform.position + new Vector3(-1f, 2f, 0), gameObject.transform.rotation);
	    		Instantiate(orb2, gameObject.transform.position + new Vector3(1f, 2f, 0), gameObject.transform.rotation);
	    		Instantiate(orb1, gameObject.transform.position + new Vector3(1f, -2f, 0), gameObject.transform.rotation);
	    		Instantiate(orb2, gameObject.transform.position + new Vector3(-1f, -2f, 0), gameObject.transform.rotation);
	    		Instantiate(orb1, gameObject.transform.position + new Vector3(2f, 1f, 0), gameObject.transform.rotation);
	    		Instantiate(orb2, gameObject.transform.position + new Vector3(2f, -1f, 0), gameObject.transform.rotation);
	    		Instantiate(orb1, gameObject.transform.position + new Vector3(-2f, -1f, 0), gameObject.transform.rotation);
	    		Instantiate(orb2, gameObject.transform.position + new Vector3(-2f, 1f, 0), gameObject.transform.rotation);
	    		start = 0;
                }


    	}}
        
    }
}
