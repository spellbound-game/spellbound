using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class arenamanasys : MonoBehaviour{
	
    public int p1mana;
    public int p2mana;
    public float manaregentime;
    private float counter;
    private int p1manamax;
    private int p2manamax;
	public int potions1;
	public int potions2;
    public bool hints = true;


    public void Awake()
    {
        //DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        p1manamax = p1mana;
        p2manamax = p2mana;
    }
	void Update(){
		counter += Time.deltaTime;
		if (counter >= manaregentime){
			if (p1mana < p1manamax){
				p1mana += 1;
			}
			if (p2mana < p2manamax){
				p2mana += 1;
			}
			counter = 0;
		}

		if (Input.GetButtonDown("mana1")){
			if (potions1 > 0 && p1mana < p1manamax){
				p1mana = p1mana + 40;
				potions1 -=1;

			}
		}
		if (Input.GetButtonDown("mana2")){
			if (potions2 > 0 && p2mana < p2manamax){
				p2mana = p2mana + 40;
				potions2 -=1;

			}
		}
		if (p1mana > p1manamax){
			p1mana = p1manamax;
		}
		if (p2mana > p2manamax){
			p2mana = p2manamax;
		}

	}
}
