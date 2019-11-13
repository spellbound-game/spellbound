using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheild2 : MonoBehaviour
{
	public GameObject sheildPrefab;
	private int p2mana;
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
            p2mana = GameObject.Find("healthsystem").GetComponent<healthsystem>().p2mana;
        }else{
            p2mana = GameObject.Find("healthsystem").GetComponent<arenamanasys>().p2mana;
            }

       
        if (p2mana < manapersec){
        	holding = false;
            sheilding = false;
        }
        

        if (Input.GetButton("sheild2"))

        {
        	//Debug.Log("button down");
            if (p2mana >= initialmana){
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
            GameObject.Find("healthsystem").GetComponent<healthsystem>().p2mana -= initialmana ;;
            }else{
            GameObject.Find("healthsystem").GetComponent<arenamanasys>().p2mana -= initialmana ;;

            }sheilding = true;

    }
}
