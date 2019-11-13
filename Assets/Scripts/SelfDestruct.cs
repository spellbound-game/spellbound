using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    public int timer = 0;
    private ParticleSystem ps;
    // Use this for initialization
    void Start () {
        ps = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (timer > 5)
        {
            ps.enableEmission = false;
        }
        if (timer > 50)
        {
            Destroy(gameObject);
        }
	}
}
