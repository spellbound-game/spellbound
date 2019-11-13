using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class become_active : MonoBehaviour

{
	public GameObject check;
    // Start is called before the first frame update
    void Start()
    {
       check.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnDisable(){
    	check.gameObject.SetActive(true);
    }
   
}
