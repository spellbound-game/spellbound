using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_2_spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public GameObject spawnpoint;
    //public GameObject boss;
    // Update is called once per frame

    void update(){
    	//spawnpoint = boss.transform.position;
    }
    void OnDisable(){
    	Instantiate(prefab, spawnpoint.transform.position, gameObject.transform.rotation);
    	Instantiate(prefab, spawnpoint.transform.position+ new Vector3(0.0f, 1f , 0f), gameObject.transform.rotation);
    	Instantiate(prefab, spawnpoint.transform.position+ new Vector3(1f, 1f , 0f), gameObject.transform.rotation);
    	Instantiate(prefab, spawnpoint.transform.position+ new Vector3(1.5f, 1f , 0f), gameObject.transform.rotation);
    	Instantiate(prefab, spawnpoint.transform.position+ new Vector3(0.0f, .5f , 0f), gameObject.transform.rotation);
    	Instantiate(prefab, spawnpoint.transform.position+ new Vector3(.5f, 1f , 0f), gameObject.transform.rotation);
    	Instantiate(prefab, spawnpoint.transform.position+ new Vector3(1f, .5f , 0f), gameObject.transform.rotation);
    	Instantiate(prefab, spawnpoint.transform.position+ new Vector3(.5f, .5f , 0f), gameObject.transform.rotation);
    	Instantiate(prefab, spawnpoint.transform.position+ new Vector3(1.5f, .5f , 0f), gameObject.transform.rotation);
    	Instantiate(prefab, spawnpoint.transform.position+ new Vector3(.5f,1.5f , 0f), gameObject.transform.rotation);
    	Instantiate(prefab, spawnpoint.transform.position+ new Vector3(1f, 1.5f , 0f), gameObject.transform.rotation);

    }


    }

