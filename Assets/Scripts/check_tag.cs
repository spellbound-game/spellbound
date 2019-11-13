using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_tag : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thing_to_activate;
    private GameObject check;
    void Start()
    {
        thing_to_activate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    	GameObject[] check;
    	check = GameObject.FindGameObjectsWithTag("Monster");
    	if (check.Length == 0  ){
    		thing_to_activate.SetActive(true);
    	} 
    }
}
