using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_self_x : MonoBehaviour
{
    // Start is called before the first frame update
    public float time_to_death;

    // Update is called once per frame
    void Update()
    {
        time_to_death -= Time.deltaTime;
        if (time_to_death < 0){
        	gameObject.SetActive( false);
        }
    }
}
