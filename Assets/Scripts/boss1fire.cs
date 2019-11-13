using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1fire : MonoBehaviour
{
	private Vector3 target;
	public int whichpoint;
	private GameObject player;
	public int speed;

	void Start(){
		if (whichpoint == 1){
			 player = GameObject.Find("Point1");
		}
		if (whichpoint == 2){
			 player = GameObject.Find("Point2");
		}
		if (whichpoint == 3){
			 player = GameObject.Find("Point3");
		}
	}
    // Update is called once per frame
    void Update()
    {
    	target =  player.transform.position;
    	float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

 void OnTriggerEnter2D(Collider2D enemy)
    {
        //Debug.Log("I hit " + enemy.gameObject.tag );

        //if ((gameObject.name ==  "target_p2(Clone)" && enemy.gameObject.name == "player1") || (gameObject.name ==  "target_p1(Clone)" && enemy.gameObject.name == "player2")  ){
            
            //Debug.Log("hellow ther");
        
        	if (enemy.gameObject.tag != "ignore" && enemy.gameObject.tag != "Respawn" && enemy.gameObject.tag != "Hazard" && enemy.gameObject.name != "Basilisk" ){
                //GameObject obj = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
                Destroy(gameObject);}
        }

    }

