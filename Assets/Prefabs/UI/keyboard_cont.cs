using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class keyboard_cont : MonoBehaviour
{
	public GameObject display;

	void Start(){
		display = GameObject.Find("displayText");
	}

    // Start is called before the first frame update
     public void letter(){
     	//Debug.Log(display.GetComponent<dispaly_name>().display);
     	GameObject child = gameObject.transform.GetChild(0).gameObject;
     	//Debug.Log(child.GetComponent<Text>().text);
     	if (display.GetComponent<dispaly_name>().display.Length < 8){
     	display.GetComponent<dispaly_name>().display += child.GetComponent<Text>().text ;
    	 }

     }
     public void del(){
     	if (display.GetComponent<dispaly_name>().display.Length > 0){
     		display.GetComponent<dispaly_name>().display = display.GetComponent<dispaly_name>().display.Substring(0, display.GetComponent<dispaly_name>().display.Length - 1);
     	}
     }
     public void back(){
     	SceneManager.LoadScene(sceneName: "Menu");
     }

     public void cont(){
     	GameObject.Find("healthsystem").GetComponent<healthsystem>().team_name = display.GetComponent<dispaly_name>().display;
     	int rando_easy = Random.Range(2,7);
        SceneManager.LoadScene(rando_easy);
     }



   
}
