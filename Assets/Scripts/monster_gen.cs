using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_gen : MonoBehaviour {

    public Transform spawnPoint;
    public GameObject monsterPrefab;
	// Update is called once per frame
	
    void Update(){
        if (gameObject.activeSelf == false){
        generate();
    }}
    void generate ()
    {
        // shooting logic
        Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}