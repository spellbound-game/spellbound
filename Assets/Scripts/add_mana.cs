using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class add_mana : MonoBehaviour {

 private bool use = false;
  public int points;
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
    //Debug.Log(isarena);
    if (other.gameObject.tag == "Player") {
      if (use == false){

        if (isarena == false){
          if (GameObject.Find("healthsystem").GetComponent<healthsystem>().potions < 5){
          	use = true;
          	gameObject.SetActive(false) ;
          	GameObject.Find("healthsystem").GetComponent<healthsystem>().potions += 1;
          	GameObject.Find("healthsystem").GetComponent<healthsystem>().score += points;
      	   }
          if (GameObject.Find("healthsystem").GetComponent<healthsystem>().potions >= 5){
            use = true;
            gameObject.SetActive(false) ;
            //GameObject.Find("healthsystem").GetComponent<healthsystem>().potions += 1;
            GameObject.Find("healthsystem").GetComponent<healthsystem>().score += points;
          }}else{

            if (other.gameObject.name == "playerArena1"){
                if (GameObject.Find("healthsystem").GetComponent<arenamanasys>().potions1 < 5){
                use = true;
                gameObject.SetActive(false) ;
                GameObject.Find("healthsystem").GetComponent<arenamanasys>().potions1 += 1;
               }
              if (GameObject.Find("healthsystem").GetComponent<arenamanasys>().potions1 >= 5){
                use = true;
                gameObject.SetActive(false) ;
                //GameObject.Find("healthsystem").GetComponent<healthsystem>().potions += 1;
              }}else{
                if (GameObject.Find("healthsystem").GetComponent<arenamanasys>().potions2 < 5){
                use = true;
                gameObject.SetActive(false) ;
                GameObject.Find("healthsystem").GetComponent<arenamanasys>().potions2 += 1;
               }
              if (GameObject.Find("healthsystem").GetComponent<arenamanasys>().potions2 >= 5){
                use = true;
                gameObject.SetActive(false) ;
              }}
      }
    }
  }
}}
