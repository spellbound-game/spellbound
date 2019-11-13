using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyItem : MonoBehaviour {
    public int points;
    private bool used = false;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            if (used == false)
            {
                used = true;
                GameObject.Find("healthsystem").GetComponent<healthsystem>().currency += points;
            }


        }
    }
}
