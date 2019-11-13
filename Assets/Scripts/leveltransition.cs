using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leveltransition : MonoBehaviour {
	public  int SceneIndex;
	public bool activated = false;
	private int count = 0;
	public string type;
	public int num_easy;
	public int num_med;
	public int num_hard;
	public int num_boss;

	void Start(){

		if (type == "E"){
			//pick rando medium level
			SceneIndex = Random.Range(num_easy+2,num_easy +num_med+2);
		}
		if (type == "M"){
			//pick rando hard  level
			SceneIndex = Random.Range(num_easy+ num_med+2,num_easy+ num_med + num_hard+2);
		}
		if (type == "H"){
			//pick rando boss level
			SceneIndex = Random.Range(num_med + num_easy+ num_hard +2,num_med + num_easy+ num_hard + num_boss+2);
		}
		if (type == "B"){
			//go back to highscore page
			SceneIndex = 1;
		}
		if (type == "NEXT"){
			SceneIndex = SceneManager.GetActiveScene().buildIndex +1;
		}
		if (type == "R"){
			SceneIndex = SceneManager.GetActiveScene().buildIndex;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")){
			count = count +1;
			if (count >= 6){
				activated = true;
			}
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag("Player")){
			count = count -1;}
}


}
