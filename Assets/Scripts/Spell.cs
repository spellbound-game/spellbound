using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    public Transform firePoint;
    public Transform firepointdown;
    public GameObject spellPrefab;
    private int p1mana;
    public bool isarena = false;

    public AudioClip impact;
    AudioSource audioSource;

  void Start () {
		audioSource = GameObject.Find("AudioController").GetComponent<AudioSource>();
	}
	void Update () {
		if (isarena){
        p1mana = GameObject.Find("healthsystem").GetComponent<arenamanasys>().p1mana;
    	}else{p1mana = GameObject.Find("healthsystem").GetComponent<healthsystem>().p1mana;}

    	if (Input.GetButton("firedown1") && Input.GetButtonDown("Fire1")){
    		if (p1mana >= 25){
                 Shootdown();
            }
    	}
    	
		if (Input.GetButtonDown("Fire1") && (Input.GetButton("firedown1") != true))
        {
        	 if (p1mana >= 25){
                 Shoot();
            }

        }
	}

	void Shootdown()
	{
		Debug.Log("i ran");
		audioSource.PlayOneShot(impact, 0.1F);
        Instantiate(spellPrefab, firepointdown.position, firepointdown.rotation);
        if (isarena){ GameObject.Find("healthsystem").GetComponent<arenamanasys>().p1mana -=25;;
        }else{GameObject.Find("healthsystem").GetComponent<healthsystem>().p1mana -= 25 ;;}
	}
    void Shoot ()
    {
        // shooting logic
        audioSource.PlayOneShot(impact, 0.1F);
        Instantiate(spellPrefab, firePoint.position, firePoint.rotation);
        if (isarena){ GameObject.Find("healthsystem").GetComponent<arenamanasys>().p1mana -=25;;
        }else{GameObject.Find("healthsystem").GetComponent<healthsystem>().p1mana -= 25 ;;}
    }
}
