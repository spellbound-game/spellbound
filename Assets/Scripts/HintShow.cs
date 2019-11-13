using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintShow : MonoBehaviour {
    //private Collider2D range;
    private SpriteRenderer sprite;
    public string tag;
    public string input;
    private GameObject item;
    // Use this for initialization
    void Start() {
        //range = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        if(GameObject.FindGameObjectsWithTag("Item").Length > 0){
            item = GameObject.FindGameObjectsWithTag("Item")[0];
            }else{
                item = GameObject.Find("player1");
            }
    }
    void Update()
    {
        if (item.activeSelf == false){
                    sprite.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((!Input.GetButton(input)) && (GameObject.Find("healthsystem").GetComponent<healthsystem>().hints == true))
        {   item = other.gameObject;
            if (other.gameObject.tag == tag)
            {

                if (tag == "Respawn")
                {
                    if (other.gameObject.GetComponent<Animator>().GetBool("isActive") == true)
                    {
                        sprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    }
                    else
                    {
                        sprite.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    }
                }
                else
                {
                    sprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
            }
        }
        else
        {
            sprite.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == tag)
        {
            sprite.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
    }
}
