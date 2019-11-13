using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music_controller : MonoBehaviour {

		public static AudioSource AudioPlayer;
		public AudioClip menu;
		public AudioClip forest;
		public AudioClip cave;
		private AudioClip current_clip;

	 	private static music_controller instance = null;
		public static music_controller Instance{
			get {return instance;}
		}
		void Start(){
			//current_clip = menu;
		}
		void Awake() {
				/*int sceneID = SceneManager.GetActiveScene().buildIndex;
				if (sceneID >= 1 && sceneID <= 4){
							if (current_clip != forest){
							ChangeMusic(forest);
						}
				} else{
					if ((sceneID >= 5 && sceneID <= 8)){
						if (current_clip != cave){
						ChangeMusic(cave);
						}
					} else{
						if (current_clip != menu){
						ChangeMusic(menu);
						}
					}
				}*/
				if (instance != null && instance != this){
					Destroy(this.gameObject);
					return;
				}
				else{
					instance = this;
				}
				DontDestroyOnLoad(this.gameObject);

     }

		 public void ChangeMusic(AudioClip music){
			 AudioPlayer.Stop();
			 AudioPlayer.clip = music;
			AudioPlayer.Play();
		 }



}
