using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class Library : MonoBehaviour
{
    // Start is called before the first frame update

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










	private string path;
	private GameObject temp;
  private string type;

    void Awake(){
    	string[] newprechunks =  AssetDatabase.FindAssets("_", new[] {"Assets/Resources/library3/Chunks"});
        

        foreach(string i in newprechunks)
        {   
        	/////////////////////////////////
        	//get path of chunk 
            path = AssetDatabase.GUIDToAssetPath(i);
            path = path.Substring(0, path.Length -7);
           	path = path.Substring(17);


           	//////////////////////////////
           	//turn path into gameobject
           	temp = Resources.Load(path) as GameObject;

            ////look at type
            type = temp.GetComponent<info>().chunktype;



           	/////////////////////////////
           	//add object to repective list
           	if (type.Contains("end")){
           		end.Add(temp);
           	}
           	else if (type.Contains("start")){
           		start.Add(temp);
           	}
            else if (type.Contains("save")){
                save.Add(temp);
            }
            else if (type.Contains("Rkey")){
                Rkeys.Add(temp);
            }
            else if (type.Contains("Bkey")){
                Bkeys.Add(temp);
            }
           	// else if (type.Contains("branch")){
           	// 	branch.Add(temp);
           	// }
           	else{ 
           		all.Add(temp);
	           	if (type.Contains("puz")){
	           		puz.Add(temp);
	           	}
	           	if (type.Contains("big")){
	           		big.Add(temp);
	           	}
	           	if (type.Contains("crate")){
	           		crate.Add(temp);
	           	}
	           	if (type.Contains("rev")){
	           		rev.Add(temp);
	           	}
              if (type.Contains("down")){
                down.Add(temp);
              }
              if (type.Contains("plat")){
                plat.Add(temp);
              }
              if (type.Contains("Rbranch")){
                Rbranch.Add(temp);
              }
              if (type.Contains("Lbranch")){
                Lbranch.Add(temp);
              }
              

	        }
           	///////////////////////////////



            

        }


    }

}
