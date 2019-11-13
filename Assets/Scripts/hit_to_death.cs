using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hit_to_death : MonoBehaviour {
	public int hits_initial;
	public int hits_current;
  public int points;
  public GameObject deathprefab;
	
	
	private SpriteRenderer renderer;

	public float flashTime;
	Color origionalColor;	// Use this for initialization

	void Start()
	{
		renderer = GetComponent<SpriteRenderer>();
		origionalColor = renderer.color;
		hits_current = hits_initial;
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
        if (bullet.gameObject.tag == "bullet")
				{
						FlashRed();
        		//Debug.Log(count);
						hits_current = hits_current - bullet.GetComponent<bullet>().damage;
            if(hits_current <= 0)
						{
                //Destroy(gameObject);
                GameObject.Find("healthsystem").GetComponent<healthsystem>().score += points; ;
                gameObject.SetActive(false);
						}
						Destroy(bullet.gameObject);
				}
		}
	void OnCollisionEnter2D(Collision2D hazard){
		//Debug.Log("hit" + hazard.gameObject.tag  + " "+ gameObject.tag);
		if(gameObject.tag == "Monster" && hazard.gameObject.tag == "Hazard")
			{
				FlashRed();
				Instantiate(deathprefab, gameObject.transform.position, gameObject.transform.rotation);
        		//Debug.Log(count);
						
            
                //Destroy(gameObject);
                //GameObject.Find("healthsystem").GetComponent<healthsystem>().score += points; ;
                gameObject.SetActive(false);
            
			}
	}
}
