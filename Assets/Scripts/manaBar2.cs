using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manaBar2 : MonoBehaviour {

    public RectTransform size;
    public float currentMana = 210;
    public bool isarena = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if (isarena == true){
            currentMana = 210 * (GameObject.Find("healthsystem").GetComponent<arenamanasys>().p2mana / 75f);
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, currentMana);

        }else{
        currentMana = 210 * (GameObject.Find("healthsystem").GetComponent<healthsystem>().p2mana / 75f);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, currentMana);
    }
}}
