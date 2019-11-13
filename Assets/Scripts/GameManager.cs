using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public Image ctrl_img;
    public GameObject pauseMenu;
    public GameObject endMenu;
    public GameObject winMenu;
    private GameObject p1;
    private GameObject p2;

    private bool pausable = true;

    public AudioClip pause_sound;
    public AudioClip resume_sound;
    public bool isarena = false;
    AudioSource Music;
    AudioSource SoundFX;

    void Start(){
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
      p1 = players[0];
      p2 = players[1];

      SoundFX = GameObject.Find("AudioController").GetComponent<AudioSource>();
      Music = GameObject.Find("MusicController").GetComponent<AudioSource>();
    }

    void Update()
    {   

        if ((Input.GetButtonDown("pause")) && (pausable == true))
        {
            //Debug.Log("pause toggle");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (ctrl_img.enabled == true)
        {
            if (Input.anyKey)
            {
                ctrl_img.enabled = false;
            }
        }
        if ((!p1.activeSelf) && (!p2.activeSelf)){
          Debug.Log("no active players");
          EndGame();
        }
        if (isarena && ((!p1.activeSelf) || (!p2.activeSelf))){
            Debug.Log("ye");

            EndGame();
        }
        if (isarena ==false && ((GameObject.Find("healthsystem").GetComponent<healthsystem>().lives == 0) && ((!p1.active) || (!p2.active))))
        {
            Debug.Log("yello");
            EndGame();
        }
        if (GameObject.Find("portal")){
          if (GameObject.Find("portal").GetComponent<leveltransition>().activated == true)
          {
              LevelWin();
          }
        }
    }

    public void Resume()
    {
        //Debug.Log("resume");
        Music.Play(0);
        pauseMenu.SetActive(false);
        SoundFX.PlayOneShot(resume_sound, 0.1F);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        Music.Pause();
        pauseMenu.SetActive(true);
        SoundFX.PlayOneShot(pause_sound, 0.1F);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    void LevelWin()
    {
        winMenu.SetActive(true);
        pausable = false;
    }
    void EndGame()
    {
        //Music.Pause();
        endMenu.SetActive(true);
        //SoundFX.PlayOneShot(pause_sound, 0.1F);
        //Time.timeScale = 0f;
        //GameIsPaused = true;
    }
    public void LoadMenu(){
      Time.timeScale = 1f;
      GameIsPaused = false;
      SceneManager.LoadScene("Menu");
    }
    public void LoadPortalScene()
    {
      SceneManager.LoadScene(GameObject.Find("portal").GetComponent<leveltransition>().SceneIndex);
    }

    public void QuitGame(){
      //to be implimented
    }
    public void RestartLevel(){
        string scene = SceneManager.GetActiveScene().name ;
        //Debug.Log(scene);
        if (scene == "Test1"){
            //Debug.Log("i ran");
            GameObject.Find("healthsystem").GetComponent<healthsystem>().lives = 3;
            GameObject.Find("healthsystem").GetComponent<healthsystem>().score = 0;
            GameObject.Find("healthsystem").GetComponent<healthsystem>().currency = 0;
            
            pauseMenu.SetActive(false);
            
            Music.Play(0);
            SoundFX.PlayOneShot(resume_sound, 0.1F);
            Time.timeScale = 1f;
            GameIsPaused = false;
           SceneManager.LoadScene(scene);//GameObject.Find("portal").GetComponent<leveltransition>().SceneIndex);
            }else
        {if(isarena == false){
                    
                    GameObject.Find("healthsystem").GetComponent<healthsystem>().lives = 3;
                    GameObject.Find("healthsystem").GetComponent<healthsystem>().score = GameObject.Find("HighScoreManager").GetComponent<ResetScore>().keep_score;
                    pauseMenu.SetActive(false);
                    
                    Music.Play(0);
                    SoundFX.PlayOneShot(resume_sound, 0.1F);
                    Time.timeScale = 1f;
                    GameIsPaused = false;
                    SceneManager.LoadScene(Application.loadedLevel);
                    }
        if (isarena == true){
        Time.timeScale = 1f;
        GameIsPaused = false;
        //GameObject.Find("healthsystem").GetComponent<healthsystem>().lives = 3;
        //GameObject.Find("healthsystem").GetComponent<healthsystem>().score = GameObject.Find("HighScoreManager").GetComponent<ResetScore>().keep_score;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(Application.loadedLevel);
        }}
    }
    public void ShowControls(){
        ctrl_img.enabled = true;
    }


}
