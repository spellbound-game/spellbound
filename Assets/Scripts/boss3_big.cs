using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3_big : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage = 50;
    public GameObject prefab;
    public int direction;
    
    /*
    private Vector3 targetDir;
    public Transform target1;
    public Transform target2;
    */
    //public GameObject boss;
	

	// Use this for initialization
	void Start () {
		
		//target1 = GameObject.Find("target1").transform;
		/*
		target1 = boss.Transform.position + new Vector3(-1f,-1f,0f);
		target2 = boss.Transform.position + new Vector3(-1f,-1f,0f);
		*/
		if( direction == 1){
			rb.velocity = transform.right * speed;}
			//Debug.Log(transform.right);
		if( direction == 2){
			rb.velocity = transform.right * -speed;}
		if( direction == 3){
			rb.velocity = transform.up * -speed;}
		if (direction ==  4){
 			rb.velocity = transform.TransformDirection (Vector3.forward * speed);
		}
		if (direction ==  5){
 			rb.velocity = transform.TransformDirection (Vector3.forward * speed);
		}
		}
		/*
		if( direction == 4){
			targetDir = target1 - transform.position;
			 float angle = Vector3.Angle(targetDir, transform.forward) * speed;}


		if( direction == 5){

			targetDir = target2 - transform.position;
			 float angle = Vector3.Angle(targetDir, transform.forward) * speed;}
		*/	
	

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D enemy)
    {
        //Debug.Log("I hit " + enemy.gameObject.tag );

        if (enemy.gameObject.tag == "Monster"){
            //Destroy(enemy.gameObject);
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);

        }else{
        	if (enemy.gameObject.tag != "ignore" && enemy.gameObject.tag != "Respawn" && enemy.gameObject.tag != "Hazard" && enemy.gameObject.name != "boss3"){
                Instantiate(prefab, transform.position, transform.rotation);
                Destroy(gameObject);}
        }

    }

}
