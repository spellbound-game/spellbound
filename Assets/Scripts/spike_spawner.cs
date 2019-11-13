using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_spawner : MonoBehaviour

{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    public bool spikes;
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;
    
    public GameObject spikePrefab;
    public float timer;
    private float inittimer;
    public float totaltimer;
    private float inittotal;
    
    // Update is called once per frame
    void Start(){
    	inittimer = timer;
    	inittotal = totaltimer;

    }
    void Update()
    {
    	
    	if (gameObject.GetComponent<boss2>().spikes){
    	pos1 = player1.transform.position + new Vector3(0.0f, (10.0f+Random.Range(0f, 2f)) , .5f);
    	pos2 = player2.transform.position + new Vector3(0.0f, (10.0f+Random.Range(0f, 2f)), .5f);
    	pos3 = player1.transform.position + new Vector3((Random.Range(-3f,3f)), (Random.Range(1f, 4f)+10f),.5f);
    	pos4 = player2.transform.position + new Vector3((Random.Range(-3f,3f)), (Random.Range(1f, 4f)+10f),.5f);
    	totaltimer -= Time.deltaTime;
    	timer -= Time.deltaTime;
    	if (timer < 0){
    		timer = inittimer;
    		 Instantiate(spikePrefab, pos1, gameObject.transform.rotation);
    		 Instantiate(spikePrefab, pos2, gameObject.transform.rotation);
    		 Instantiate(spikePrefab, pos3, gameObject.transform.rotation);
    		 Instantiate(spikePrefab, pos4,  gameObject.transform.rotation);


    	}
    	if (totaltimer <0){
    		gameObject.GetComponent<boss2>().spikes = false ;;
    		gameObject.GetComponent<boss2>().sleeping = true ;;
    		totaltimer = inittotal;
    		gameObject.transform.position = gameObject.GetComponent<boss2>().start ;;
    		
    	}

        
    }}
}
