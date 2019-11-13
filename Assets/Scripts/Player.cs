using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[System.Serializable]
	public class PlayerStats {
		public int Health = 1;
		public int XP = 0;
	}
	
	public PlayerStats playerStats = new PlayerStats();
	
	public void DamagePlayer(int dmg){
		playerStats.Health -= dmg;
		if (playerStats.Health <= 0) {
			GameMaster.KillPlayer(this);
		}
	}
	void Update() {
		if (transform.position.y <= -20){
			DamagePlayer(1);
		}
	}
	void OnTriggerEnter2d(Collider2D Hazard){
		if(Hazard.gameObject.tag == "Hazard"){
			DamagePlayer(1);
		}
		if(Hazard.gameObject.tag == "Monster"){
			DamagePlayer(1);
		}
	}

}
