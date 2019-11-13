using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class ore_puz_simp : MonoBehaviour
{
    // Start is called before the first frame update
    public int num_chunks;
    public GameObject current_anch;
    private Object current_chunk;
    private List<string> puz_list = new List<string>();
    private string path;
    private string tem;
    public int queue_size;
    private int chunk_num = 0;
    private int rev_placed = 0;
    public int rev_space;
    private int puz_placed = 0;
    public int puz_space;
    private  List<string> chunks = new List<string>();
    private int getcount = 0;
    private string last1;
    private string last2;
    private Stack<string> crates = new Stack<string>();
    /* This algo differes from ORE_simple becasue it intitues a queue type structure limiting the placement of the chunks, the queue_size determines 
    how often the same chunk can repeat, if queue size is 10, then every 11th chunk could possibly be the same but it is still random. 
    This algo also 

    
        */

    private float timecounter = .5f;
    void Start()
    {
    	string[] prechunks =  AssetDatabase.FindAssets("_", new[] {"Assets/Resources/library2/Starts"});
        path = AssetDatabase.GUIDToAssetPath(prechunks[Random.Range(0, prechunks.Length)]);
        path = path.Substring(0, path.Length -7);
    	path = path.Substring(17);
    	current_chunk = Resources.Load(path);
    	Instantiate(current_chunk, gameObject.transform.position, gameObject.transform.rotation);
    	last2 = path;
    	last1 = path;
        string[] newprechunks =  AssetDatabase.FindAssets("_", new[] {"Assets/Resources/library2/Chunks"});
        

        foreach(string i in newprechunks)
        {    
            tem = AssetDatabase.GUIDToAssetPath(i);
            tem = tem.Substring(0, tem.Length -7);
        
            tem = tem.Substring(17);
            chunks.Add(tem);

        }
       
        //Debug.Log(chunks.Count);
    }



    void Update(){

        // make a counter for visualization
        Debug.Log(timecounter);
        if (timecounter > 0 ){
            timecounter-= Time.deltaTime;
        }else{




        //counter end 
    	if (crates.Count > 0){Debug.Log(crates.Peek());}
    	
    	Debug.Log(crates.Count);
    	if (num_chunks > 0){
    		GameObject[] anch_list;
    		anch_list = GameObject.FindGameObjectsWithTag("anchor");
    		current_anch = anch_list[anch_list.Length -1];

            Get();

    		

            last2 = last1;
            last1 = path;
    		current_chunk = Resources.Load(path);
            chunk_num +=1;
    		Instantiate(current_chunk, current_anch.transform.position, gameObject.transform.rotation);
 
    		num_chunks -= 1;
    	}else
    	{
    		if (crates.Count == 0)
    		{
    		    		string[] prechunks =  AssetDatabase.FindAssets("_", new[] {"Assets/Resources/library2/Ends"});
    		    		GameObject[] anch_list;
    		    		anch_list = GameObject.FindGameObjectsWithTag("anchor");
    		    		current_anch = anch_list[anch_list.Length -1];
    		    		
    		    		path = AssetDatabase.GUIDToAssetPath(prechunks[Random.Range(0, prechunks.Length)]);
    			        path = path.Substring(0, path.Length -7);
    			    	path = path.Substring(17);
    			    	current_chunk = Resources.Load(path);
    		    		Instantiate(current_chunk, current_anch.transform.position, gameObject.transform.rotation);
    		    		gameObject.SetActive(false);
    		}else if(crates.Peek() == "c")
    		{
    			string[] prechunks =  AssetDatabase.FindAssets("big", new[] {"Assets/Resources/library2/Chunks"});
	    		GameObject[] anch_list;
	    		anch_list = GameObject.FindGameObjectsWithTag("anchor");
	    		current_anch = anch_list[anch_list.Length -1];
	    		
	    		path = AssetDatabase.GUIDToAssetPath(prechunks[Random.Range(0, prechunks.Length)]);
		        path = path.Substring(0, path.Length -7);
		    	path = path.Substring(17);
		    	current_chunk = Resources.Load(path);
	    		Instantiate(current_chunk, current_anch.transform.position, gameObject.transform.rotation);
	    		crates.Pop();
    		}else{
    			GameObject[] anch_list;
	    		anch_list = GameObject.FindGameObjectsWithTag("anchor");
    			path = "library2/chunks/_flatcrate1";
    			current_chunk = Resources.Load(path);
	    		Instantiate(current_chunk, current_anch.transform.position, gameObject.transform.rotation);
	    		crates.Pop();
    		}
    	}

    timecounter = .5f;}
}
    void Get( ){//List<string> ls){


        getcount += 1;


        List<string> possible = chunks.Except(puz_list).ToList();
        //Debug.Log(possible.Count);
        if (last1.Contains("down") || last2.Contains("down")){
        	var newList = possible.Where(x => x.Contains("rise")).ToList();

        	possible = possible.Except(newList).ToList();

        }

        if (crates.Count > 0 && crates.Peek() == "r"){
        	var newls = possible.Where(x => x.Contains("big")).ToList();

        	possible = possible.Except(newls).ToList();
        }

        path = (possible[Random.Range(0, possible.Count)]);
        
        if (getcount > 5){
            //Debug.Log("I ran");
            path = "library2/Chunks/_flat";
            getcount = 0;
        }
        else
        {
        //dont add rev tagged to list, keep track of last rev placed
            if  (puz_list.Contains(path))
            {
                Get();
            }
            else if(path.Contains("rev"))
            {
                if (chunk_num - rev_placed < rev_space)
                {
                    Get();
                }
                else
                {
                    rev_placed = chunk_num;
                    getcount = 0;
                }
            }

            //puzzle spacing 
            else if(path.Contains("puz"))
            {
                if (chunk_num- puz_placed < puz_space)
                {
                    Get();
                }
                else if (path.Contains("puz"))
                {    
                    puz_list.Add(path);
                    puz_placed = chunk_num;
                    getcount = 0;

                }
            }
            else
            {
                    puz_list.Add(path);
                    getcount = 0;
            }
        }

        if (path.Contains("crate")){
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
        if (path.Contains("big"))
        {
        	if (crates.Count > 0 )
        	{ 
        		crates.Pop();
        	}
        	else
        	{
        		crates.Push("r");
        	}

        }



        if (puz_list.Count > queue_size)
        {
            puz_list = puz_list.GetRange(1,puz_list.Count-1);
        }
    }



}
