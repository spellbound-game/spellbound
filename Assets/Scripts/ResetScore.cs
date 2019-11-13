using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScore : MonoBehaviour {
    public int[] high_scores = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    public Hashtable name_scores = new Hashtable();
    private int score;
    public int keep_score;
    private int scene = 0;
    private int current_scene = 0;
    public string name;

    // Use this for initialization
    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(name_scores.Count);
        current_scene = SceneManager.GetActiveScene().buildIndex;

        if (current_scene != scene && (SceneManager.GetActiveScene().name != "arena1" || SceneManager.GetActiveScene().name != "arena2)"))
        {
            //Debug.Log("runnning");
            scene = current_scene;
            if (current_scene == 0) //menu
            {
                //Debug.Log("menu");
                score = GameObject.Find("healthsystem").GetComponent<healthsystem>().score;
                name = GameObject.Find("healthsystem").GetComponent<healthsystem>().team_name;
                if (score != 0)
                {   
                    while( name_scores.ContainsKey(score)){
                        score -= 1;
                    }
                    high_scores[0] = score;
                    name_scores.Add(score, name);
                    high_scores = InsertionSort(high_scores);
                    Reset();
                }
            }
            else
            {
              keep_score = GameObject.Find("healthsystem").GetComponent<healthsystem>().score;
            }
        }
    }
    static int[] InsertionSort(int[] inputArray)
    {
        for (int i = 0; i < inputArray.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (inputArray[j - 1] > inputArray[j])
                {
                    int temp = inputArray[j - 1];
                    inputArray[j - 1] = inputArray[j];
                    inputArray[j] = temp;
                }
            }
        }
        return inputArray;
    }

    void Reset ()
    {
        GameObject.Find("healthsystem").GetComponent<healthsystem>().lives = 3;
        GameObject.Find("healthsystem").GetComponent<healthsystem>().score = 0;
        GameObject.Find("healthsystem").GetComponent<healthsystem>().currency = 0;
        GameObject.Find("healthsystem").GetComponent<healthsystem>().potions = 0;
        GameObject.Find("healthsystem").GetComponent<healthsystem>().team_name = "";

    }
}
