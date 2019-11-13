using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dispaly_name : MonoBehaviour
{
	//public string display = "";
	public string display;
    // Start is called before the first frame update

	void Start(){
		display = "";
	}
    // Update is called once per frame
    void Update()
    {
      gameObject.GetComponent<Text>().text = display.ToString();

    }
}
