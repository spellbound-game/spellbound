using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetwoardplayer : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public GameObject Whichplayer;
    public float speed;
    private Vector3 target;
    public int damage = 50;
    public GameObject prefab;


    // Update is called once per frame
    void Start(){
        


        player = GameObject.Find(Whichplayer.name);
        
    }
    void Update()
    {
    	
        

        if (player.activeSelf == false){
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);}


    
    }
    void LateUpdate(){
       
        target =  player.transform.position;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
    void OnTriggerEnter2D(Collider2D enemy)
    {
        //Debug.Log("I hit " + enemy.gameObject.tag );

        if ((gameObject.name ==  "target_p2(Clone)" && enemy.gameObject.name == "player1") || (gameObject.name ==  "target_p1(Clone)" && enemy.gameObject.name == "player2")  ){
            
            //Debug.Log("hellow ther");
        }else{
        	if (enemy.gameObject.tag != "ignore" && enemy.gameObject.tag != "Respawn" && enemy.gameObject.tag != "Hazard" && enemy.gameObject.name != "boss3" ){
                Instantiate(prefab, transform.position, transform.rotation);
                Destroy(gameObject);}
        }

    }

}

