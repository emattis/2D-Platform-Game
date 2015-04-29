using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	//Collision2D fireCollider;

	[System.Serializable]

	public class PlayerStats {
		public int Health = 100;
	}

	void Start(){
		//fireCollider = GameObject.Find("Fire").GetComponent<Collision2D>();

	}
	

	public PlayerStats playerStats = new PlayerStats();

	public int fallBoundary = -20;

	void Update () {
		if (transform.position.y <= fallBoundary)
			DamagePlayer (9999999);

		//DamagePlayerWithFire (fireCollider);
	}

	public void DamagePlayer (int damage) {
		playerStats.Health -= damage;
		if (playerStats.Health <= 0) {
			GameMaster.KillPlayer(this);
		}
	}

		void DamagePlayerWithFire(Collision2D col){
		if (col.transform.tag == "Fire") {
			Debug.Log ("I am touching fire, kill me please :)");
			GameMaster.KillPlayer (this);
		}
	}
	

	void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("Testing");
		if (other.transform.tag == "movingPlatform") {
			transform.parent = other.transform;
		} else {
			if(other.transform.tag == "Fire")
				DamagePlayerWithFire(other);
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.transform.tag == "movingPlatform") {
			transform.parent = null;
		}
	}
}
