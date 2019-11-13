using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sheildbehavior2 : MonoBehaviour
{
	//public Transform location;
	public bool holding;
    private GameObject player;
    private Vector3 pos;
    private int manapersec;
    public float timer;
    public float killtimer;
    public bool isarena = false;
	

    // Start is called before the first frame update
    void Start()
    {
       char x = SceneManager.GetActiveScene().name[0];
        if (x == 'a'){
        isarena = true;
        if (isarena ==false){
           player =  GameObject.Find("player2");
        }else{
            player = GameObject.Find("playerArena2");
        } 
        }
        timer = player.GetComponent<sheild1>().timer;
        killtimer = player.GetComponent<sheild1>().killtimer;
    }

    // Update is called once per frame
    void Update(){
    	if (isarena ==false){
           player =  GameObject.Find("player2");
        }else{
            player = GameObject.Find("playerArena2");
        }
    	
    	pos = player.transform.position;
    	holding = player.GetComponent<sheild2>().holding;
    	manapersec = player.GetComponent<sheild2>(). manapersec;
    	timer -= Time.deltaTime;





     	if ( timer <= 0f){
     		if (isarena ==false){
            GameObject.Find("healthsystem").GetComponent<healthsystem>().p2mana -= manapersec ;;
            }else{
                GameObject.Find("healthsystem").GetComponent<arenamanasys>().p2mana -= manapersec;;
            }  
     		timer = .5f;}

    	if (!holding){
    	 	killtimer -= Time.deltaTime;
    	 	if (killtimer <= 0f){
    	 		gameObject.SetActive(false);

    	 	}

    	     	 	
    	 }

    	 transform.position = pos;


        
    }

}
