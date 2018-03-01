using UnityEngine;
using System.Collections;


// EnemyShot.cs
// author: Maksym Bardus
// ID: 100953577
// COMP3064
// Last modified by Maksym Bardus
// Date last modified: Nov26, 2017
// Desciption: EnemyShot.cs moves EnemyShot's clones and destroy them when they are not on the scene
// Revision 0.1  -  11.26.17  -  class created and all methods are implemented

public class EnemyShot : MonoBehaviour {
	[SerializeField]
	private float speed;

	private Transform transform;
	private Vector2 _currentPos;

	void Start () {
		transform = gameObject.GetComponent<Transform>();
		_currentPos = transform.position;
	}

	// moves Enemyshot clones and destroys them when they are no longer visible
	void Update () {
		_currentPos = transform.position;

		_currentPos -= new Vector2 (speed, 0);
		transform.position = _currentPos;

		if (_currentPos.x <= -6) {
            Destroy (this.gameObject);
		}
	}

	// calculates health
	void OnTriggerEnter2D(Collider2D other)
	{
		PlayerController pl = GameObject.Find("Player").gameObject.GetComponent<PlayerController> ();
		GameObject gm = GameObject.Find ("GameManager");
		GameManager gmComponent = gm.GetComponent<GameManager> ();
		if (other.CompareTag ("Player")){

			gmComponent.Health = gmComponent.Health - 5;
			print ("Health: " + gmComponent.Health);
		} 

	}
}
