using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endtext : MonoBehaviour{
	//public bool isplayer1;
	public float wait;
	public GameObject menu_button;
	public GameObject text;
	public string words;


    // Start is called before the first frame update
    void Start()
    {
    	menu_button.GetComponent<Button>().interactable = false;
    	GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
    	if (player.name == "playerArena1"){
    		words = "Player1 Wins!";

    	}else{
    		words = "Player2 Wins!";
    		text.GetComponent<Text>().color = Color.blue ;

    	}
        
    }

    // Update is called once per frame
    void Update()
    {
    	text.GetComponent<Text>().text = words;
    	wait -= Time.deltaTime;
    	if (wait <0){
    	menu_button.GetComponent<Button>().interactable = true;

    	}

        
    }
}
