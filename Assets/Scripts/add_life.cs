using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class add_life : MonoBehaviour {

  private bool use = false;
  public int points;
  //private bool used = false;
  public bool isarena = false;
  //private bool used = false;
  void Start(){
  char x = SceneManager.GetActiveScene().name[0];
  if (x == 'a'){
    isarena = true;

  }
 }

	// Use this for initialization
  void OnTriggerEnter2D(Collider2D other) {
    
    if (other.gameObject.tag == "Player") {
      if (use == false){
        if(isarena == false){
            if (GameObject.Find("healthsystem").GetComponent<healthsystem>().lives < 5){
            	use = true;
            	gameObject.SetActive(false) ;
            	GameObject.Find("healthsystem").GetComponent<healthsystem>().lives += 1;
            	GameObject.Find("healthsystem").GetComponent<healthsystem>().score += points;
            }
            if (GameObject.Find("healthsystem").GetComponent<healthsystem>().lives >= 5){
              use = true;
              gameObject.SetActive(false) ;
              //GameObject.Find("healthsystem").GetComponent<healthsystem>().lives += 1;
              GameObject.Find("healthsystem").GetComponent<healthsystem>().score += points;
        	}}else{

                if (other.GetComponent<ArenaHealth>().health < 5){
                use = true;
                gameObject.SetActive(false) ;
                other.GetComponent<ArenaHealth>().health += 1;
               }
              if (other.GetComponent<ArenaHealth>().health >= 5){
                use = true;
                gameObject.SetActive(false) ;
                //GameObject.Find("healthsystem").GetComponent<healthsystem>().potions += 1;
              }
      }
          }
      }
    }
  }

