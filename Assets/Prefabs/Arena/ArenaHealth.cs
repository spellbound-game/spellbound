using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaHealth : MonoBehaviour {


	public int health;
	//public int count = 0;
	public GameObject prefab;
	public bool hit;
	private SpriteRenderer renderer;
	public float flashTime;
	private Color origionalColor;
	//public GameObject ui;
	//public int mana;

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

		
	void Update(){
		if (hit){
			health -= 1;
			FlashRed();
			
            if(health <= 0){
			
						Instantiate(prefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
		}
		hit =false;
	}
		
     }}


