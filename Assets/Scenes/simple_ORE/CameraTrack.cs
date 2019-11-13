using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam;
    private GameObject[] ls;
    public float timescale;
    public float speed;
    private GameObject target;
    public Camera cam1;
    void Start()
    {
        Time.timeScale = 1;
        //cam1 = cam;
    }

    // Update is called once per frame
    void Update()
    {
        ls =GameObject.FindGameObjectsWithTag("anchor");

        target = cam.GetComponent<CameraController>().player2 = ls[ls.Length-1];
        //cam1.orthographicSize = ls.Length;




    }
    void LateUpdate()
    {
    	
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, target.transform.position + new Vector3(0,0,-10), speed);
    }
}
