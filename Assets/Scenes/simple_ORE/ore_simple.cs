using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ore_simple : MonoBehaviour
{
    // Start is called before the first frame update
    public int num_chunks;
    public GameObject current_anch;
    private Object current_chunk;


    void Start()
    {
    	string[] chunks =  AssetDatabase.FindAssets("_", new[] {"Assets/Resources/library/Starts"});
        string path = AssetDatabase.GUIDToAssetPath(chunks[Random.Range(0, chunks.Length)]);
        path = path.Substring(0, path.Length -7);
    	path = path.Substring(17);
    	current_chunk = Resources.Load(path);
    	Instantiate(current_chunk, gameObject.transform.position, gameObject.transform.rotation);
    }
    void Update(){
    	if (num_chunks > 0){
    		GameObject[] anch_list;
    		anch_list = GameObject.FindGameObjectsWithTag("anchor");
    		current_anch = anch_list[anch_list.Length -1];


    		string[] chunks =  AssetDatabase.FindAssets("_", new[] {"Assets/Resources/library/Chunks"});


    		//random

            string path = AssetDatabase.GUIDToAssetPath(chunks[Random.Range(0, chunks.Length)]);
            //Debug.Log(path);
            path = path.Substring(0, path.Length -7);
            //Debug.Log(path);

    		//random part
    		//string path = AssetDatabase.GetAssetPath(chunks[0]);
    		//string t = AssetDatabase.AssetPathToGUID("Assets/Resources/library/a72867f94cc1f05498301895bb0e650f");
    		//Debug.Log(path);
    		//object hi = chunks[0];
            path = path.Substring(17);
            //Debug.Log(path);

    		current_chunk = Resources.Load(path);
    		Instantiate(current_chunk, current_anch.transform.position, gameObject.transform.rotation);
 
    		num_chunks -= 1;
    	}else{
    		string[] chunks =  AssetDatabase.FindAssets("_", new[] {"Assets/Resources/library/Ends"});
    		GameObject[] anch_list;
    		anch_list = GameObject.FindGameObjectsWithTag("anchor");
    		current_anch = anch_list[anch_list.Length -1];
    		
    		string path = AssetDatabase.GUIDToAssetPath(chunks[Random.Range(0, chunks.Length)]);
	        path = path.Substring(0, path.Length -7);
	    	path = path.Substring(17);
	    	current_chunk = Resources.Load(path);
    		Instantiate(current_chunk, current_anch.transform.position, gameObject.transform.rotation);
    		gameObject.SetActive(false);
    	}
    }



}
