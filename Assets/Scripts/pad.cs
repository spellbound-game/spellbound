using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pad : MonoBehaviour {
	public Sprite padup;
	public Sprite paddown;
	private SpriteRenderer spriteRenderer;
	//public Transform pressDetection;
	public bool pressed = false;
	private GameObject thing;
	//private float distance = .2f;

	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag != "ignore" && other.gameObject.tag != "Respawn"  && other.gameObject.tag != "collectable"){
		pressed = true;
		thing = other.gameObject;}
	}
	void OnTriggerExit2D(Collider2D other){
		pressed = false;
	}

	void Update(){
		if(pressed == false)
			{
				//pressed = true;
				spriteRenderer.sprite = padup;
			}
		else{
			spriteRenderer.sprite = paddown;
			if (thing.activeInHierarchy == false){
				pressed = false;
			}
		}
	}}
	/*
	void Update(){
		RaycastHit2D press = Physics2D.Raycast(pressDetection.position, Vector2.up, distance);
		if(press.collider == true)
		{
			if(pressed == false)
			{
				pressed = true;
				spriteRenderer.sprite = paddown;
			}
		}
		else
		{
			if(pressed==true)
			{
				pressed = false;
				spriteRenderer.sprite = padup;
			}
		}



		if(pressed==true){
			//Console.Log("press!!!");
		}
	}

 */

