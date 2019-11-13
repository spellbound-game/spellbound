using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell2 : MonoBehaviour {

    public Transform firePoint;
    public GameObject spellPrefab;
    private int p2mana;
    public bool isarena = false;

    public AudioClip impact;
    AudioSource audioSource;
    void Start () {
  		audioSource = GameObject.Find("AudioController").GetComponent<AudioSource>();
  	}
    void Update(){
        if (isarena){
        p2mana = GameObject.Find("healthsystem").GetComponent<arenamanasys>().p2mana;
        }else{p2mana = GameObject.Find("healthsystem").GetComponent<healthsystem>().p2mana;}


        if (Input.GetButtonDown("Fire2"))
        {
            if (p2mana >= 25){
                 Shoot();
            }

        }}
    void Shoot()
    {
        // shooting logic
        audioSource.PlayOneShot(impact, 0.1F);
        Instantiate(spellPrefab, firePoint.position, firePoint.rotation);
        if (isarena){ GameObject.Find("healthsystem").GetComponent<arenamanasys>().p2mana -=25;;
        }else{GameObject.Find("healthsystem").GetComponent<healthsystem>().p2mana -= 25 ;;}
    }
}
