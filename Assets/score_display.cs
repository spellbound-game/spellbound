using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_display : MonoBehaviour {
    private int[] high_scores = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private string displayString;
    private Hashtable name_strings;

    public Text displayText;

    // Use this for initialization
    void Start () {
        high_scores = GameObject.Find("HighScoreManager").GetComponent<ResetScore>().high_scores;
        displayText = GetComponent<Text>();
        name_strings =  GameObject.Find("HighScoreManager").GetComponent<ResetScore>().name_scores;
        
    }
	
	// Update is called once per frame
	void Update () {
        //high_scores = GameObject.Find("HighScoreManager").GetComponent<ResetScore>().high_scores;

        for (int i = 10; i > 0; i--)
        {
            if (high_scores[i] != 0)
            {
                //Debug.Log(high_scores[i].ToString());
                //displayString += ((11 - i).ToString() + "st:   " + high_scores[i].ToString() + "\n");
                displayString += (name_strings[high_scores[i]] + "     " + high_scores[i].ToString() + "\n");
            }
        }
        displayText.text = displayString;
        displayString = "";
    }
}
