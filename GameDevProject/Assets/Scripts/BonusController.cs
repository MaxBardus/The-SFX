using UnityEngine;
using System.Collections;

// BonusController.cs
// author: Maksym Bardus
// ID: 100953577
// COMP3064
// Last modified by Maksym Bardus
// Date last modified: Nov26, 2017
// Desciption: BonusController.cs controls bouns objects' position on scene, places them randomly and reset when collision with player occur
// Revision 0.1  -  11.26.17  -  class created and all methods are implemented

public class BonusController : MonoBehaviour {

	[SerializeField]
	private float speed;

	private Transform transform;
    private Vector2 _currentPos;



	void Start () {
		transform = gameObject.GetComponent<Transform>();
		_currentPos = transform.position;
		Reset ();
	}
		
	// moves bonus objects, resets it when they are no longer visible
	void FixedUpdate () {
		_currentPos = transform.position;
		_currentPos -= new Vector2 (speed, 0);
		transform.position = _currentPos;
		if (_currentPos.x <= -9) {
			Reset ();
		}

	}

	// add one to collected bonuses when player object intersects with bonus object
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			AudioSource audio = gameObject.GetComponent<AudioSource> ();
			if (audio != null) {
				audio.Play ();
			}
			GameObject gm = GameObject.Find ("GameManager");
			GameManager gmComponent = gm.GetComponent<GameManager>();
			gmComponent.Bonus +=2;
			print("Bonus collected: "+gmComponent.Bonus);
			this.Reset();
		}
		if (other.CompareTag ("bonus")) {
			_currentPos.x = other.transform.position.x + 5f;
			_currentPos.y = other.transform.position.y + 5f;
		}
	}

	// places bonus objects in random positions
	private void Reset(){
		float ypos = Random.Range (-2f, 2f);
		float xpos = Random.Range (7f, 30f);
		_currentPos = new Vector2 (xpos, ypos);
		transform.position = _currentPos;
	}

	}

