using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSpell1 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject spellPrefab;
    private int p1mana;

    public AudioClip impact;
    AudioSource audioSource;

  void Start () {
		audioSource = GameObject.Find("AudioController").GetComponent<AudioSource>();
	}
	void Update () {
        p1mana = GameObject.Find("healthsystem").GetComponent<healthsystem>().p1mana;

		if (Input.GetButtonDown("Fire1"))
        {
            if (p1mana >= 25){
                 Shoot();
            }

        }
	}
    void Shoot ()
    {
        // shooting logic
        audioSource.PlayOneShot(impact, 0.1F);
        Instantiate(spellPrefab, firePoint.position, firePoint.rotation);
        GameObject.Find("healthsystem").GetComponent<healthsystem>().p1mana -= 25 ;;
    }
}
