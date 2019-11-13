using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3_control : MonoBehaviour
{
    // Start is called before the first frame update
    public bool orbs = false;
    public bool fly = false;
    public bool fire =  false;
    public bool fly2 = false;
    private Vector3 start;
    public bool sleep = true;
    private int hits = 0;
    private int action;
    public float actiontimer;
    private float actionstart = 0;
    public float sleepspeed;
    public bool movetosleep;


    void Start()
    {
        start = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!sleep){
            actionstart += Time.deltaTime;
            if (actionstart > actiontimer){
                fly = false;
                orbs = false;
                fire = false;
                fly2 = false;
                movetosleep = true;
                actionstart = 0;


            }}
        if (movetosleep){
            //Debug.Log("hey");
            float step = sleepspeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, start, step);
            if (transform.position == start){
                sleep= true;
                movetosleep= false;
            }

        }

        }
        

        
    
    void OnTriggerEnter2D(Collider2D bullet) {
        
        if (bullet.gameObject.tag == "bullet"){
            
            hits += 1;}
            if (sleep){
                action =  Random.Range (0, 2);
                if (action == 1){
                    sleep = false;
                    fly = true;
                    orbs = true;
                }
                if (action == 0){
                    sleep = false;
                    fly2 = true;
                    fire = true;
                }
            }
}}
