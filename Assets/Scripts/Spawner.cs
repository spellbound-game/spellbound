using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
	public float timer;
	//private bool detect;
	public GameObject item1;
	private float initial;
	public Transform spawnpoint;
    private GameObject check;
    public GameObject item2;
    private GameObject[] movePoints;
    //public Vector3 target;

	void Start(){

		initial = timer;
        movePoints = GameObject.FindGameObjectsWithTag("point");
		
	}
    // Update is called once per frame
    void Update()
    {
        GameObject[] check;
        check = GameObject.FindGameObjectsWithTag("collectable");
        if (check.Length == 0){
        	timer -= Time.deltaTime;
         	if ( timer <= 1f){
         		generate();
         		timer = initial;}
            }
        
    }

    void generate ()
    {
        int choice = Random.Range(1,3);
        int place = Random.Range(0,movePoints.Length);
        if (choice == 1){
        
        Instantiate(item1, movePoints[place].transform.position, movePoints[place].transform.rotation);
        }else{
        Instantiate(item2, movePoints[place].transform.position, movePoints[place].transform.rotation);

        }
    }
}
