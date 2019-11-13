using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintsToggle : MonoBehaviour
{
    // Start is called before the first frame update
    private bool hints = true;
    void Start()
    {
        if (GameObject.Find("healthsystem").GetComponent<healthsystem>().hints == false)
        {
            GetComponent<Toggle>().isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHints()
    {
        if (hints == true)
        {
            hints = false;
            GameObject.Find("healthsystem").GetComponent<healthsystem>().hints = false;
        }
        else
        {
            hints = true;
            GameObject.Find("healthsystem").GetComponent<healthsystem>().hints = true;
        }
    }
}
