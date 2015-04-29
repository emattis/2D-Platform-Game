using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public static GameMaster gm;
	public static int lives = 3;
	
	void Start () {
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
		}
	}
	
	public Transform playerPrefab;
	public Transform spawnPoint;
	public float spawnDelay = 2;
	public Transform spawnPrefab;
	
	public IEnumerator RespawnPlayer () {
		audio.Play ();
		yield return new WaitForSeconds (spawnDelay);
		
		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
		GameObject clone = Instantiate (spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
		Destroy (clone, 3f);
	}
	
	public static void KillPlayer (Player player) {
		Destroy (player.gameObject);
		gm.StartCoroutine (gm.RespawnPlayer());
		lives = lives - 1;
		Debug.Log ("You have " + lives + " left");

		if (GameOver()) {
			Debug.Log("Game Over");
		}
	}

	public static void KillEnemy (Enemy  enemy){
		Destroy (enemy.gameObject);
	}

	public static bool GameOver (){
		int x = lives;

		if (x == 0) {
			Debug.Log("Game Over");
			return true;
		}
		return false;
	}
}