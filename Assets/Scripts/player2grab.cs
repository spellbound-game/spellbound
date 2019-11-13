using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2grab : MonoBehaviour {
    private bool grab;
    public Transform holdpoint;
    private bool grabbing;
    private bool canhold =false;
    private GameObject item;
    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.tag == "Item") {
               other.gameObject.GetComponent<GrabItem>().isGrabable = true;
               canhold = true;
               item = other.gameObject;

            }}
    void OnTriggerExit2D(Collider2D other) {
         if (other.gameObject.tag == "Item") {
               other.gameObject.GetComponent<GrabItem>().isGrabable = false;
               canhold = false;
               item = other.gameObject;

            }


        }
    void OnDisable(){
        grabbing = false;
        canhold = false;
        //item.gameObject.GetComponent<GrabItem>().isGrabable = false;;
    }
    /*private void OnTriggerExit2D(Collider2D other) {
       if (other.gameObject.tag == "Item") {
            Debug.Log("Grab now false");

            grab = false;
        }}*/
    void Update(){
            if (canhold){
                if (Input.GetButtonDown("grab2")){
                    grabbing = true;
                    item.GetComponent<GrabItem>().Grabbed = true;
                }
                }
            if (grabbing){
                item.transform.position = holdpoint.position;
            }
            if (Input.GetButtonUp("grab2")){
                    grabbing = false;
                    item.GetComponent<GrabItem>().Grabbed = false;
                }



    }


}
