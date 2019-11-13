using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed_tag : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject check;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	speed = gameObject.GetComponent<patrolAI>().speed;
        GameObject[] check;
    	check = GameObject.FindGameObjectsWithTag("Monster");
    	gameObject.GetComponent<patrolAI>().speed = 14-check.Length;;
    }
}
