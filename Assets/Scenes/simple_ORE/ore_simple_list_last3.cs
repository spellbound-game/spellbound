using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class ore_simple_list_last3 : MonoBehaviour
{
    // Start is called before the first frame update
    public int num_chunks;
    public GameObject current_anch;
    private Object current_chunk;
    private List<Object> puz_list = new List<Object>();
    private string path;
    private string tem;
    public int queue_size;
    private int chunk_num = 0;
    private int rev_placed = 0;
    public int rev_space;
    private int puz_placed = 0;
    public int puz_space;
    private  List<Object> chunks = new List<Object>();
    private int getcount = 0;
    private string last1;
    private string last2;
    /* This algo differes from ORE_simple becasue it intitues a queue type structure limiting the placement of the chunks, the queue_size determines 
    how often the same chunk can repeat, if queue size is 10, then every 11th chunk could possibly be the same but it is still random. 
        */
    void Start()
    {
    	//string[] prechunks =  AssetDatabase.FindAssets("_", new[] {"Assets/Resources/library/Starts"});
    	Object[] startchunks =  Resources.LoadAll("library/Starts");
        //Debug.Log(startchunks.Length);
        //path = AssetDatabase.GUIDToAssetPath(prechunks[Random.Range(0, prechunks.Length)]);
        current_chunk = startchunks[Random.Range(0, startchunks.Length)];
    	Instantiate(current_chunk, gameObject.transform.position, gameObject.transform.rotation);
    	last2 = current_chunk.name;
    	last1 = current_chunk.name;
        //string[] newprechunks =  AssetDatabase.FindAssets("_", new[] {"Assets/Resources/library/Chunks"});
        Object[] chunkz =  Resources.LoadAll("library/Chunks");
        //Debug.Log(chunkz.Length);
        foreach (Object i in chunkz){
            chunks.Add(i);
        }
        /*
        foreach(object i in newprechunks)
        {    
            tem = AssetDatabase.GUIDToAssetPath(i);
            tem = tem.Substring(0, tem.Length -7);
        
            tem = tem.Substring(17);
            chunks.Add(tem);

        }
        */
        //Debug.Log(chunks.Count);
    }
    void Update(){
    	if (num_chunks > 0){
    		GameObject[] anch_list;
    		anch_list = GameObject.FindGameObjectsWithTag("anchor");
    		current_anch = anch_list[anch_list.Length -1];

            Get();

    		

            last2 = last1;
            last1 = current_chunk.name;
    		//current_chunk = Resources.Load(path);
            chunk_num +=1;
    		Instantiate(current_chunk, current_anch.transform.position, gameObject.transform.rotation);
 
    		num_chunks -= 1;
    	}else{
    		Object[] endchunks =  Resources.LoadAll("library/Ends");
    		GameObject[] anch_list;
    		anch_list = GameObject.FindGameObjectsWithTag("anchor");
    		current_anch = anch_list[anch_list.Length -1];
    		
    		current_chunk = (endchunks[Random.Range(0, endchunks.Length)]);
    		Instantiate(current_chunk, current_anch.transform.position, gameObject.transform.rotation);
    		gameObject.SetActive(false);
    	}
    }
    void Get( ){//List<string> ls){
        getcount += 1;
        //Debug.Log(last1);
        //Debug.Log(last2);


        List<Object> possible = chunks.Except(puz_list).ToList();
        //Debug.Log("hi" +chunks.Count);

        
       // Debug.Log(puz_list);
        if (last1.Contains("down") || last2.Contains("down")){
        	var newList = possible.Where(x => x.name.Contains("rise")).ToList();
        	//Debug.Log("start");
        	//Debug.Log(possible.Count);
        	possible = possible.Except(newList).ToList();
        	//Debug.Log(possible.Count);
        }
        //Debug.Log(possible.Count);

        current_chunk = (possible[Random.Range(0, possible.Count)]); 
        
        if (getcount > 5){
            //Debug.Log("I ran");
            current_chunk = Resources.Load("library/Chunks/_flat");
            getcount = 0;
        }
        else
        {
        //dont add rev tagged to list, keep track of last rev placed
            if  (puz_list.Contains(current_chunk))
            {
                Get();
            }
            else if(current_chunk.name.Contains("rev"))
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
            else if(current_chunk.name.Contains("puz"))
            {
                if (chunk_num- puz_placed < puz_space)
                {
                    Get();
                }
                else if (current_chunk.name.Contains("puz"))
                {    
                    puz_list.Add(current_chunk);
                    puz_placed = chunk_num;
                    getcount = 0;

                }
            }
            else
            {
                    puz_list.Add(current_chunk);
                    getcount = 0;
            }
        }
            
            
        


        if (puz_list.Count > queue_size)
        {
            puz_list = puz_list.GetRange(1,puz_list.Count-1);
        }
    }



}
