using UnityEngine;
using System.Collections;

// PlayerController.cs
// author: Maksym Bardus
// ID: 100953577
// COMP3064
// Last modified by Maksym Bardus
// Date last modified: Nov26, 2017
// Desciption: PlayerController.cs controls player object' behaviour and position on scene and instantiate shots when fire1 is pressed
// Revision 0.1  -  11.26.17  -  class created and all methods are implemented


[System.Serializable]
public class PlayerController : MonoBehaviour {
	[SerializeField]
	private float speed;

	public GameObject ShotObj;
	public Transform ShotSuper;
	public GameObject ShotSuperObj;
	public Transform Shot;
	public float fireRate;
	private float nextFire;

	private Transform transform;
    private Vector2 _currentPos;
    private float pInputY;
    private float pInputX;

	void Start () {
		transform = gameObject.GetComponent<Transform>();
		_currentPos = transform.position;
	}
	// instantiate shot clones when "Fire1" is pressed
	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject gm = GameObject.Find ("GameManager");
			GameManager gmComponent = gm.GetComponent<GameManager> ();
		
			AudioSource audio = gameObject.GetComponent<AudioSource> ();
			if (audio != null) {
				audio.Play ();
			}
			if (gmComponent.Health >= 95) {
				Instantiate (ShotSuperObj, ShotSuper.position, ShotSuper.rotation);
			} else {
				Instantiate (ShotObj, Shot.position, Shot.rotation);
			}
		} 

	}
	

	// moves player up, down, right and left
	void FixedUpdate () {

		pInputY = Input.GetAxis ("Vertical");
		pInputX = Input.GetAxis ("Horizontal");
		_currentPos = transform.position;
		// move up
		if (pInputY > 0) {
			_currentPos += new Vector2 (0,speed);
		}
		// move down
		if (pInputY < 0) {
			_currentPos -= new Vector2 (0, speed);
		}
		// move right
		if (pInputX > 0) {
			_currentPos += new Vector2 (speed,0);
		}
		// move left
		if (pInputX < 0) {
			_currentPos -= new Vector2 (speed*1.5f,0);
		}

		Boundaries ();
		transform.position = _currentPos;
	}

	// keeps player within the scene
    private void Boundaries(){

		if (_currentPos.y < -2.7f) {
			_currentPos.y = -2.7f;
		}
		if (_currentPos.y > 2.7f) {
			_currentPos.y = 2.7f;
		}
		if (_currentPos.x < -6f) {
			_currentPos.x = -6f;
		}
		if (_currentPos.x > 6f) {
			_currentPos.x = 6f;
		}
	}

}
