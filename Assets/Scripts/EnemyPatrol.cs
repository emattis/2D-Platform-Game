using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	private bool atEdge;
	public Transform edgeCheck;

	
	// Update is called once per frame
	void Update () {

		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall) 
			moveRight = !moveRight;

		if (moveRight) {
			transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
			rigidbody2D.velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		} else {

			transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
			rigidbody2D.velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}
	
	}
}
