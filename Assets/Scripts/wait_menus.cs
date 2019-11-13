using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wait_menus : MonoBehaviour
{
    // Start is called before the first frame update
    public float wait;
	public GameObject menu_button;
	public GameObject restart_but;
    void Start()
    {
    	menu_button.GetComponent<Button>().interactable = false;
        restart_but.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        wait -= Time.deltaTime;
    	if (wait <0){
    	menu_button.GetComponent<Button>().interactable = true;
    	restart_but.GetComponent<Button>().interactable = true;
    }
}}
