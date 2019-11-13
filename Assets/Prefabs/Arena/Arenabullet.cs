using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arenabullet : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 50;
    public GameObject prefab;


	// Use this for initialization
	void Start () {
        rb.velocity = transform.right * speed;
	}

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D enemy)
    {
        //Debug.Log("I hit " + enemy.gameObject.tag );
        
        if (enemy.gameObject.tag == "Player"){
            enemy.gameObject.GetComponent<ArenaHealth>().hit = true;

            //Destroy(enemy.gameObject);
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);

        }else{
        	if (enemy.gameObject.tag != "ignore" && enemy.gameObject.tag != "Respawn" && enemy.gameObject.tag != "collectable"){
                Instantiate(prefab, transform.position, transform.rotation);
                Destroy(gameObject);}
        }
 
    }

}
