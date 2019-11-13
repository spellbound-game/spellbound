using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_spawner : MonoBehaviour
{
	public GameObject trigger1;
	public bool on1 = false;
	public GameObject prefab;

    // Update is called once per frame
    void Update()
    {
    	GameObject[] check;
        check = GameObject.FindGameObjectsWithTag("Monster");
        //Debug.Log(check.Length);
        Debug.Log(trigger1.GetComponent<pad>().pressed);
		on1 = trigger1.GetComponent<pad>().pressed;

		if (check.Length == 1 && on1==true){
			Instantiate(prefab,transform.position,transform.rotation);
		

		}
    }
}
