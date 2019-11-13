using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviveDisplay : MonoBehaviour {
    public Text DisplayMessage1;
    public Text DisplayMessage2;
    public GameObject P1;
    public GameObject P2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (P1.activeSelf)
        {
            DisplayMessage2.enabled = false;
        }
        if (P2.activeSelf)
        {
            DisplayMessage1.enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("enter");
        if (coll.gameObject == P1)
        {
            if (!P2.activeSelf)
            {
                DisplayMessage1.enabled = true;
            }
        }
        if (coll.gameObject == P2)
        {
            if (!P1.activeSelf)
            {
                DisplayMessage2.enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        Debug.Log("exit");
        if (coll.gameObject == P1)
        {
            Debug.Log("p1");
            DisplayMessage1.enabled = false;
        }
        if (coll.gameObject == P2)
        {
            Debug.Log("p2");
            DisplayMessage2.enabled = false;
        }
    }
}
