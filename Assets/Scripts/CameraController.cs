using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    private GameObject p1;
    private GameObject p2;
    public Camera MainCamera;
    private float distancex;
     private float distancey;
     private float corrected;
     private bool slowadjust;
     private float currentsize;
     private float size;
     private Vector3 pos;



    //private GameObject player1init = player;
    //private GameObject player2init = player2;
    //private Vector3 offset;

	// Use this for initialization
	void Start () {
		p1 = player1;
		p2 = player2;
        currentsize = 0;

	}
    void Update(){
        //Debug.Log(current);
        //Debug.Log(slowadjust);
        //Debug.Log(MainCamera.transform.position);
    	distancex =(Mathf.Abs(player1.transform.position.x - player2.transform.position.x));
    	distancey =(Mathf.Abs(player1.transform.position.y - player2.transform.position.y));
    	corrected = Mathf.Sqrt(Mathf.Sqrt (Mathf.Pow(distancex, 2) + Mathf.Pow(distancey *2, 2)));

    	//Debug.Log(distancex);

        if (p1.activeSelf == false){
            currentsize = MainCamera.orthographicSize;
            player1 = p2;
            pos = player2.transform.position;
            pos.z = -10;


            slowadjust = true;


        }
        if (p2.activeSelf == false){
            currentsize = MainCamera.orthographicSize;
            player2 = p1;
            pos = player1.transform.position;
            pos.z = -10;

             slowadjust = true;



        }
        if (p1.activeSelf){
            player1 = p1;


            //slowadjust = false;

        }
        if (p2.activeSelf){
            player2 = p2;

            //slowadjust = false;

        }
    }



    // Update is called once per frame
    void LateUpdate () {

        size = corrected + Screen.width/200;
        if (!slowadjust){
           pos = (player2.transform.position - player1.transform.position) / 2 + player1.transform.position;
           pos.z = -10;
            transform.position = Vector3.MoveTowards(transform.position, pos, 15 * Time.deltaTime);
            if (corrected > Screen.width/200 ){
                MainCamera.orthographicSize = size + (corrected-Screen.width/200)*2 ;//Screen.width/200 ;//+ Mathf.Sqrt(corrected) ;

            }else{
            MainCamera.orthographicSize =  size;}//Screen.width/200 ;//+ Mathf.Sqrt(corrected) ;

        }else{
            transform.position = Vector3.MoveTowards(transform.position, pos, 17 * Time.deltaTime);


            if (currentsize> size +1.5){
                currentsize -= .05f;
                MainCamera.orthographicSize = currentsize;

            }else{
                slowadjust =false;
            }

        }


    }


}
