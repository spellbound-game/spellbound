using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip menu_music;
    public AudioClip forest_music;
    public AudioClip cave_music;
    AudioSource audioSource;
    AudioSource backgroundMusic;

    //private int current_scene = 0;
    private int current_music = 0;
    // Start is called before the first frame update
    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        backgroundMusic = GameObject.Find("MusicController").GetComponent<AudioSource>();
        MenuMusic();
    }
    void MenuMusic()
    {
        backgroundMusic.clip = menu_music;
        backgroundMusic.loop = true;
        backgroundMusic.Play();
        current_music = 0;
    }
    void CaveMusic()
    {
        backgroundMusic.clip = cave_music;
        backgroundMusic.loop = true;
        backgroundMusic.Play();
        current_music = 2;
    }
    void ForestMusic()
    {
        backgroundMusic.clip = forest_music;
        backgroundMusic.loop = true;
        backgroundMusic.Play();
        current_music = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //current_scene = SceneManager.GetActiveScene().buildIndex;
        char x = SceneManager.GetActiveScene().name[0];
        //Debug.Log(x);
        if (x == 'f' || x == 'a' || x =='b')
        {
            if (current_music != 1)
            {
                //Debug.Log("forest music start");
                ForestMusic();
            }
        }
        else if (x == 'c')
        {
            if (current_music != 2)
            {
                //Debug.Log("cave music start");
                CaveMusic();
            }
        }
        else
        {
            if (current_music != 0)
            {
                //Debug.Log("menu music start");
                MenuMusic();
            }
        }
    }
}
