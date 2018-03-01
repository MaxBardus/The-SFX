using UnityEngine;
using System.Collections;

// BackgroundController.cs
// author: Maksym Bardus
// ID: 100953577
// COMP3064
// Last modified by Maksym Bardus
// Date last modified: Nov26, 2017
// Desciption: BackgroundController.cs moves first background object accordingly the scene
// Revision 0.1  -  11.26.17  -  class created and all methods are implemented

public class BackgroundController : MonoBehaviour {
	[SerializeField]
	private float speed;

	public Transform transform;
    public Vector2 _currentPos;

	void Start () {
		transform = gameObject.GetComponent<Transform>();
		_currentPos = transform.position;
	}

	// moves background, resets it when second background takes its place
	void FixedUpdate () {
		_currentPos = transform.position;
        _currentPos -= new Vector2 (speed, 0);
		transform.position = _currentPos;
		if (_currentPos.x <= -18.79) {
			Reset ();
		}
	
	}
	// resets first background
	private void Reset(){
		_currentPos = new Vector2 (15.1f,0);
		transform.position = _currentPos;
	}
}
