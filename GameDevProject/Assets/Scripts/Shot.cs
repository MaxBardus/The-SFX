using UnityEngine;
using System.Collections;

// Shot.cs
// author: Maksym Bardus
// ID: 100953577
// COMP3064
// Last modified by Maksym Bardus
// Date last modified: Nov26, 2017
// Desciption: Shot.cs moves shot's clones and destroy them when they are not on the scene
// Revision 0.1  -  11.26.17  -  class created and all methods are implemented

public class Shot : MonoBehaviour {

	[SerializeField]
	private float speed;

	private Transform transform;
    private Vector2 _currentPos;

	void Start () {
		transform = gameObject.GetComponent<Transform>();
		_currentPos = transform.position;
	}

	// moves shot clones, destroys them when they are no longer visible
	void Update () {
		_currentPos = transform.position;

		_currentPos += new Vector2 (speed, 0);
	    transform.position = _currentPos;

		if (_currentPos.x >= 7) {
			Destroy (this.gameObject);
		}
}
}