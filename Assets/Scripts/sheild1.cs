using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheild1 : MonoBehaviour
{
	public GameObject sheildPrefab;
	private int p1mana;
	public bool holding = false;
	public int manapersec = 10;
	public int initialmana = 40;
    public bool isarena = false;
    public float timer = .5f;
    public float killtimer = .5f;
    private bool sheilding = false;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update(){
        if (isarena == false){
            p1mana = GameObject.Find("healthsystem").GetComponent<healthsystem>().p1mana;
        }else{
            p1mana = GameObject.Find("healthsystem").GetComponent<arenamanasys>().p1mana;
            }
       
        if (p1mana < manapersec){
        	holding = false;
            sheilding = false;
        }
        

        if (Input.GetButton("sheild1"))

        {
        	//Debug.Log("button down");
            if (p1mana >= initialmana){
            	holding = true;
            	if (sheilding == false){
                    Sheild();
                }
            }
        }else{
            	
        		holding = false;
                sheilding = false;
                
        		
        }}

    void Sheild()
    {
        // shooting logic
        //audioSource.PlayOneShot(impact, 0.1F);
        Instantiate(sheildPrefab, gameObject.transform.position, gameObject.transform.rotation);
        if (isarena ==false){
            GameObject.Find("healthsystem").GetComponent<healthsystem>().p1mana -= initialmana ;;
            }else{
            GameObject.Find("healthsystem").GetComponent<arenamanasys>().p1mana -= initialmana ;;

            }
        sheilding = true;
    }
}
