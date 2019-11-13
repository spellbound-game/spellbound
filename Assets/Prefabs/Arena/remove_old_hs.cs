using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove_old_hs : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Destroy( GameObject.Find("healthsystem"));
        //Destroy( GameObject.Find("HighScoreManager"));
        //Destroy( GameObject.Find("AudioController"));

    }

    // Update is called once per frame
    
}
