using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3_fly : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float pointtimer;
    private float pointstart = 0;
    private int index;
    private GameObject[] movePoints;
    public Vector3 target;
    public bool fly;
    private List<int> numbers;
    private int save = 4;

    void Start()
    {
        movePoints = GameObject.FindGameObjectsWithTag("point");
        numbers = new List<int>(new int[]{0,1,2,3,4,5});
    }

    // Update is called once per frame
    void Update()
    {
    	fly = GetComponent<boss3_control>().fly;

    	if (fly){
	    	pointstart += Time.deltaTime;
	    	
			if (pointstart > pointtimer){

				index = numbers[Random.Range(0, numbers.Count)];
				numbers.Add(save);
				//Debug.Log(numbers.Count);
				save = index;
				pointstart = 0;
				numbers.Remove(index);
			}
			float step = speed * Time.deltaTime;
			target = movePoints[index].transform.position;
	    	transform.position = Vector3.MoveTowards(transform.position, target, step);
    
    }}
}
