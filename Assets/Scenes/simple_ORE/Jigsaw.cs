using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;


public class Jigsaw : MonoBehaviour
{
    // Start is called before the first frame update
	///////////////////////////
	///establish game object lists
    public GameObject Library;
    public List<GameObject> puz = new List<GameObject>();
	public List<GameObject> start = new List<GameObject>();
	public List<GameObject> end = new List<GameObject>();
	public List<GameObject> big = new List<GameObject>();
	public List<GameObject> crate = new List<GameObject>();
	public List<GameObject> all = new List<GameObject>();
	public List<GameObject> Rbranch = new List<GameObject>();
	public List<GameObject> Lbranch = new List<GameObject>();

	public List<GameObject> rev = new List<GameObject>();
	public List<GameObject> down = new List<GameObject>();
	public List<GameObject> plat = new List<GameObject>();
	public List<GameObject> save = new List<GameObject>();

    public List<GameObject> Rkeys = new List<GameObject>();
    public List<GameObject> Bkeys = new List<GameObject>();





	////////////////
	//list of coordinates of the chunks
    public List<Vector2> Coordinates = new List<Vector2>();

    
    ////////////////////////////////////////
    //////queue so that chunks dont repeat 
    public int queue_size = 10;
    private List<GameObject> chunk_queue = new List<GameObject>();

    ////////////////////////////////////////

    private List<GameObject> possible_chunks = new List<GameObject>();
	private GameObject current_chunk;
    private GameObject current_anch;
    public int total_chunks = 30;

    ////////////////////////////////////////
    ////////space out the puzzle chunks
    public int  puz_spacing = 5;
    private int puz_count = 0;

    ////////////////////////////////
    //stack for crates
    private Stack<string> crates = new Stack<string>();

	///////////////////
	///////for list removal from possible
	private List<GameObject> updated = new List<GameObject>();

	/////////////////////
	//branching(simple)
	private GameObject branch_point;
	private int branch_for;

	////////////
	///get() recurssion stop
	private int get_stop  = 30;

	//public GameObject get_stopper;
	public bool is_branch = false;

	private List<Vector2> checklist;
	
	public GameObject testblock;
	///////
	//branch limits
	public int Branch_lower_limit;
	public int Branch_upper_limit;

	/////////
	//left branching

	public bool is_left;
	private float timer = 3f;

	//public GameObject testblock;

	public int seed; 

    private bool placed_Rkey = false;
    private bool placed_Bkey = false;











    public System.Random rand1;

    void Start()
    {
   		if (seed != 0){
   			rand1 = new System.Random(seed);
			

		}else{
			seed = Random.Range(1,1000000);
    		rand1 = new System.Random(seed);


		}
		Debug.Log("Seed: " + seed.ToString());



    	puz = Library.GetComponent<Library>().puz;
    	end = Library.GetComponent<Library>().end;
    	start = Library.GetComponent<Library>().start;
    	big = Library.GetComponent<Library>().big;
    	crate = Library.GetComponent<Library>().crate;
    	all = Library.GetComponent<Library>().all;
    	Rbranch = Library.GetComponent<Library>().Rbranch;
    	Lbranch = Library.GetComponent<Library>().Lbranch;

    	rev = Library.GetComponent<Library>().rev;
    	down = Library.GetComponent<Library>().down;
    	plat = Library.GetComponent<Library>().plat;
    	save = Library.GetComponent<Library>().save;

        Rkeys = Library.GetComponent<Library>().Rkeys;
        Bkeys = Library.GetComponent<Library>().Bkeys;


    	//Debug.Log(all.Count);






    	current_anch = gameObject;
    	//current_chunk = start[Random.Range(0, start.Count-1)];
    	current_chunk = start[rand1.Next(0, start.Count-1)];

    	Instantiate(current_chunk, current_anch.transform.position, current_chunk.transform.rotation);
    	Coordinates =  MakeList(current_chunk, current_anch);
    	chunk_queue.Add(current_chunk);

    	 


    	//Get start

    	
    }


    // Update is called once per frame
    void Update()
    {

    	/////////////////////////////
    	//section for making the placement one chunk at on a timer

    	// if (timer > 2.2){
    	// 	timer -= Time.deltaTime;
    	// 	//Debug.Log(timer);
    	// }
    	// else{
    		
    	// 	timer = 3;
    		
    	///////////////////////////////	
    	

    	GameObject[] anch_list;
    	anch_list = GameObject.FindGameObjectsWithTag("anchor");
    	current_anch = anch_list[anch_list.Length -1];

    	if (current_anch.name == "left"){
    		is_left= true;

    	}else{
    		is_left =false;
    	}

    	if (is_branch){
    		//////////////////
    		///branch finishes basesed on number
	    	if (branch_for < 0){
            
	    		GameObject[] branchpoint_list;
    			branchpoint_list = GameObject.FindGameObjectsWithTag("branch");
    			current_anch.gameObject.tag="branch";
	    		current_anch= branchpoint_list[branchpoint_list.Length-1];
	    		current_anch.gameObject.tag = "Untagged";
	    		branchpoint_list[branchpoint_list.Length-1].gameObject.SetActive(false);
	    		is_branch = false;
	    		is_left = false;
	    		

	    	}
            
                



            





            else{
	    		branch_for -= 1;
	    	}
	    }


    	if (total_chunks < 0){
    		current_chunk = end[rand1.Next(0, end.Count)];
    		checklist = MakeList(current_chunk, current_anch);
    	

    	

    		List<Vector2> overlap = Coordinates.Intersect(checklist).ToList();
    		if(overlap.Count > 0){
    			current_anch.SetActive(false);
    			GameObject[] branchpoint_list;
    			branchpoint_list = GameObject.FindGameObjectsWithTag("branch");
	    		current_anch= branchpoint_list[branchpoint_list.Length-1];

    		}


    		gameObject.SetActive(false);
    	}else{
    		Get();
    	}




    	///place
    	if(is_branch == false){
    			total_chunks -= 1;
    	}
    	chunk_queue.Add(current_chunk);
    	GameObject x = Instantiate(current_chunk, current_anch.transform.position, gameObject.transform.rotation);
    	get_stop = 45;

    	if (Rkeys.Contains(current_chunk)){
        	placed_Rkey = true;
        }
        if (Bkeys.Contains(current_chunk)){
        	placed_Bkey = true;
        }

    	////////////////
    	//if we are leftward branching, rotate the chunk, and set the anchor to name "left"
    	if(is_left == true || current_anch.name == "left" ){
    		x.transform.RotateAround(current_anch.transform.position, Vector3.up, 180);

    		x.transform.Find("anchor1").gameObject.name = "left";

    		//if current chunk is in Rbranch, set branchpoint to name left
    		if (Rbranch.Contains(current_chunk)){
    			x.transform.Find("branchpoint").gameObject.name ="left";

    		}

    		//didnt work, doesnt save
    		// GameObject[] anch;
    		// anch = GameObject.FindGameObjectsWithTag("anchor");
    		// current_anch = anch_list[anch_list.Length -1];
    		// Debug.Log(current_anch.name);

    		// current_anch.name = "left";
    		// Debug.Log(current_anch.name);





    	}
    	///////////////////
    	///puz spacing








    	//////////////////////
    	//// crate stack goop
    	if (crate.Contains(current_chunk)){
        	if (crates.Count > 0 )
        	{
        		if(crates.Peek() == "r")
        		{
        			crates.Pop();
        		}else{
        			crates.Push("c");
        		}
        	}
    		else
        	{
        		crates.Push("c");
        	}
        }
        if (big.Contains(current_chunk))
        {
        	if (crates.Count > 0 )
        	{
        		if(crates.Peek() == "r")
        		{
        			Debug.Log(current_chunk.name);
        		}else{
        			crates.Pop();
        		}
        	}
    		else
        	{
        		crates.Push("r");
        	}

        }

    	//(puz.IndexOf(current_chunk) < 0);
    	//means, if the current chunk is not in the list of puzzles
    	if (puz.IndexOf(current_chunk) < 0){
    		puz_count += 1;
    	}else{
    		puz_count = 0;
    	}

    	

    	////////////
    	//fix queue
    	if (chunk_queue.Count > queue_size){
    		chunk_queue = chunk_queue.GetRange(1,chunk_queue.Count-1);
    	}

    	///////////////////
    	/// remove branchpoint from options?
    	if (current_anch.gameObject.tag == "branch"){
    		current_anch.gameObject.tag = "Untagged";
    	}
        
    //}
}
	
	
    void Get(){


    	/////////////////////
    	///make temp legal list
    	List<GameObject> possible_chunks = all.Except(chunk_queue).ToList();

    	///////
    	//if is branching cant branch again
    	if(is_branch){
    	 	possible_chunks = list_out(possible_chunks, Rbranch);
    	 	possible_chunks = list_out(possible_chunks, Lbranch);

    	}
    	



    	///////////////////////////
    	/// account for puz
    	if (puz_count <= puz_spacing){
    		possible_chunks = list_out(possible_chunks, puz);
    	}

    	///////////////////////
    	///crate check
    	if (crates.Count > 0 && crates.Peek() == "r"){

    		// if crates stack is larger than 1, and the top of the stack is a rise chunk, the next chunk cant be a rise chunk

        	possible_chunks = list_out(possible_chunks, big);

        	////cant have puz if crate stack peek is r

        	possible_chunks = list_out(possible_chunks, puz);

        }
        /////////////////////////////////
       	//cant be INBALENCE OF  larger than 1

        if (crates.Count > 1 ){
        	possible_chunks = list_out(possible_chunks, crate);
        }
        

       


        //////////////////////////
        ///plat-> rise or down down -> rise, clause
        
        if (chunk_queue.Count > 2 && ((plat.Contains(chunk_queue[chunk_queue.Count - 1]) || plat.Contains(chunk_queue[chunk_queue.Count - 2]) || down.Contains(chunk_queue[chunk_queue.Count - 1]) || down.Contains(chunk_queue[chunk_queue.Count - 2])))){
        	possible_chunks = list_out(possible_chunks, big);
        	possible_chunks = list_out(possible_chunks, Lbranch);


        }



    	
        ///////////////////////
        ////if near end and big is top of stack, pick a crate

        if(total_chunks < 5 && crates.Count == 1){
        	if (crates.Peek() == "r"){
        		possible_chunks = crate;
        	}
        }
        ////////
    	///not allowed to use save normally;
    	if (get_stop < 1){
    		possible_chunks= save;
    	}
    	
    	  ///////////////
        //place key at finsihed branch
        if (is_branch && branch_for == 0){
            if (!placed_Bkey && !placed_Rkey){
            	//Debug.Log("I ran");
                int rk = rand1.Next(0,2);
                //Debug.Log(rk);
                if (rk == 1){
                    /////////
                    //place blue key
                   	possible_chunks = Bkeys;




                }else{
                    ////////
                    //place Red key
                   	possible_chunks = Rkeys;



                }


            }else if(!placed_Bkey){
                //////
                ///place blue key
                possible_chunks = Bkeys;

            
            }else if(!placed_Rkey){
                //////
                ///place red key
                possible_chunks = Rkeys;




            }
        }



    	/////////////////////
    	//////select

    	if (possible_chunks.Count != 0){
    			//current_chunk = possible_chunks[Random.Range(0,possible_chunks.Count-1)];
    			current_chunk = possible_chunks[rand1.Next(0,possible_chunks.Count-1)];

    	}


    	/////////////////
    	//////make coord list

    	if(is_left == false){
    		checklist = MakeList(current_chunk, current_anch);

    	}else{
    		checklist = MakeLeftList(current_chunk, current_anch);


    	}
	  
    	////////////////
    	/////check list

    	

    	List<Vector2> overlap = Coordinates.Intersect(checklist).ToList();

    	if (get_stop > 0){
	     	if(overlap.Count > 0){
	     		//Debug.Log("overlap");
	     		possible_chunks.RemoveAll(x => x.name  == current_chunk.name);
    			get_stop -= 1;

	            Get();
	            
	     	}
	     	else{
	     			Coordinates.AddRange(checklist);
	       
	    	}
	    }else{
	    		
	    		if (is_branch){
	    			is_branch = false;
	    			is_left= false;
	    			GameObject[] branchpoint_list;
    				branchpoint_list = GameObject.FindGameObjectsWithTag("branch");
	    			current_anch= branchpoint_list[branchpoint_list.Length-1];
	    			get_stop = 45;
	    			Get();

	    		}else{

	    			GameObject[] branchpoint_list;
    				branchpoint_list = GameObject.FindGameObjectsWithTag("branch");
	    			current_anch= branchpoint_list[branchpoint_list.Length-1];

	    			current_anch.gameObject.tag = "Untagged";
	    			get_stop = 45;
	    			Get();

	    			}
	    	}






    	
        /////////////////////////////////
        /////////////branching
        if (Rbranch.Contains(current_chunk)|| Lbranch.Contains(current_chunk) ){
        	//branch_for = Random.Range(Branch_lower_limit,Branch_upper_limit);
        	branch_for = rand1.Next(Branch_lower_limit,Branch_upper_limit);

        	is_branch = true;
        	
        	

        }
        get_stop = 30;

       



    	
    	


    }

    List<Vector2> MakeList(GameObject current_chunk, GameObject current_anch){
    	int x1 = Mathf.FloorToInt(current_anch.transform.position[0]);
        int y1 = Mathf.FloorToInt(current_anch.transform.position[1]);
        int X = current_chunk.GetComponent<info>().x;
        int Y = current_chunk.GetComponent<info>().y;
        int y2 = current_chunk.GetComponent<info>().Begin;

        var chunk_coord = new List<Vector2>();
        for (int i = 0; i < X; i = i +1){
            for (int j = 0; j < Y; j = j+1){
                chunk_coord.Add(new Vector2((x1 +i ), (y1 - y2 + j )));
            }
        }
        return chunk_coord;
    
	}
	List<Vector2> MakeLeftList(GameObject current_chunk, GameObject current_anch){
    	int x1 = Mathf.FloorToInt(current_anch.transform.position[0]);
        int y1 = Mathf.FloorToInt(current_anch.transform.position[1]);
        int X = current_chunk.GetComponent<info>().x;
        int Y = current_chunk.GetComponent<info>().y;
        int y2 = current_chunk.GetComponent<info>().Begin;

        var chunk_coord = new List<Vector2>();
        for (int i = 0; i < X; i = i +1){
            for (int j = 0; j < Y; j = j+1){
                chunk_coord.Add(new Vector2((x1 -(i+1 )), (y1 - y2 + j )));
            }
        }

  //////////////////////////
  ///intantiate test block at coordintes
  //       foreach(Vector2 i in chunk_coord){
  //   			Instantiate(testblock, new Vector3(i[0], i[1],0) , gameObject.transform.rotation);
  //   		}
		// Debug.Log(current_chunk);
		// Time.timeScale = 0;
		

        return chunk_coord;
    
	}


	List<GameObject> list_out(List<GameObject> possible_chunks, List<GameObject> Exception){
		updated = possible_chunks.Except(Exception).ToList();
		return updated;

	}
}
	
// 	public static void Wait( int seconds )
// 	{
// 	  TimeSpan ts = DateTime.Now + TimeSpan.FromSeconds( seconds );
	 
// 	  do {} while ( DateTime.Now < ts );
// 	}
// }
