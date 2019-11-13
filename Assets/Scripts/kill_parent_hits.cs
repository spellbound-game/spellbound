using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kill_parent_hits : MonoBehaviour {

	// Use this for initialization
	public int hits_initial;
	private float count = 0;
	private SpriteRenderer renderer;
	public float flashTime = .5f;
	private Color origionalColor;
	public GameObject cratepoof;
	// Use this for initialization
	void Start(){
		renderer = GetComponent<SpriteRenderer>();
		origionalColor = renderer.color;
	}
	void FlashRed()
	{
		renderer.color = Color.red;
		Invoke("ResetColor", flashTime);
	}
	void ResetColor()
	{
		renderer.color = origionalColor;
	}
	void OnTriggerEnter2D(Collider2D bullet) {
		//Debug.Log(count);
		//Debug.Log("i " + gameObject.name +" hit by "+ bullet.gameObject.name);
        if (bullet.gameObject.tag == "bullet") {
        	Destroy(bullet.gameObject);
        	FlashRed();
        	//Debug.Log(count);
            count = count +1;

            if(hits_initial <= count){
			//Destroy(gameObject);
            	Instantiate(cratepoof, gameObject.transform.position, gameObject.transform.rotation);
            	transform.parent.gameObject.SetActive(false);
			}

         }
     }
}