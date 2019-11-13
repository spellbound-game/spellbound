using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;


public class btn_behaviors : MonoBehaviour {

    // Use this for initialization
    void Start ()
    {

    }

    public void ButtonStart()
    {
         SceneManager.LoadScene(sceneName: "name_input");
    }
     public void ButtonArena()
    {
    	List<string> arenas = new List<string>{"arena1","arena2"};
        SceneManager.LoadScene(sceneName: arenas[Random.Range(0,arenas.Count)]);
    }
    public void ButtonSettings()
    {
        SceneManager.LoadScene(sceneName: "Settings");
    }
    public void ButtonSelect()
    {
        SceneManager.LoadScene(sceneName:"Level_select");
    }
    public void ButtonScores()
    {
        SceneManager.LoadScene(sceneName: "Leaderboard");
    }
    public void ButtonControls()
    {
        SceneManager.LoadScene(sceneName: "Controls");
    }
    public void ButtonMenu()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }

    public void ButtonQuit()
    {
        Application.Quit();
        //Debug.Log("<color=red>Quit signal received</color>");
    }

    //level selects
    public void level1_btn()
    {
        //SceneManager.LoadScene(sceneName:"level1");
        int rando_easy = Random.Range(2,7);
        SceneManager.LoadScene(rando_easy);
    }
    public void level2_btn()
    {
        //SceneManager.LoadScene(sceneName:"level2");
        int rando_med = Random.Range(7,11);
        SceneManager.LoadScene(rando_med);
    }
    public void level3_btn()
    {
        //SceneManager.LoadScene(sceneName:"level3");
        int rando_hard = Random.Range(11,14);
        SceneManager.LoadScene(rando_hard);
    }
    public void level4_btn()
    {
        //SceneManager.LoadScene(sceneName:"level4");
        int rando_boss = Random.Range(14,16);
        SceneManager.LoadScene(rando_boss);
    }
    public void level5_btn()
    {
        SceneManager.LoadScene(sceneName:"cave_easy_1");
    }
    public void level6_btn()
    {
        SceneManager.LoadScene(sceneName:"test1");
    }
    public void level7_btn()
    {
        SceneManager.LoadScene(sceneName:"level7");
    }
    public void level8_btn()
    {
        SceneManager.LoadScene(sceneName:"level7");
    }
    public void comp_controls(){
        GameObject.Find("xbox_im").GetComponent<Image>().enabled = false;
        GameObject.Find("computer_im").GetComponent<Image>().enabled = true;

    }
    public void xbox_controls(){
        GameObject.Find("xbox_im").GetComponent<Image>().enabled = true;
        GameObject.Find("computer_im").GetComponent<Image>().enabled = false;
    }


    // Update is called once per frame
    void Update () {

	}
}
