using UnityEngine;
using System.Collections;

// EnemyController.cs
// author: Maksym Bardus
// ID: 100953577
// COMP3064
// Last modified by Maksym Bardus
// Date last modified: Nov26, 2017
// Desciption: EnemyController.cs controls enemy object's behaviour and position on scene and what actions need to be taken when collision occur
// Revision 0.1  -  11.26.17  -  class created and all methods are implemented
public class EnemyController : MonoBehaviour {

	[SerializeField]
	private float speed;

	private Transform transform;
    private Vector2 _currentPos;
	public GameObject EnShotObj;
	public Transform EnShot;
	public float fireRate;
	private float nextFire;

	
	private float random;
	private int gotShots = 0;
	private float timeShot;


	void Start () {
		// StartCoroutine(EnemyShot());
		this.nextFire = Random.Range (2f, 8f);
		this.fireRate=Random.Range (0.5f, 1f);
		transform = gameObject.GetComponent<Transform>();
		_currentPos = transform.position;
		random = Random.RandomRange (-0.005f,0.005f);
	}
	// moves enemy objects, resets when they are no longer visible
	void FixedUpdate () {
		if (Time.time > this.nextFire) {
			this.nextFire = Time.time + this.fireRate;
			Instantiate (this.EnShotObj, this.EnShot.position, this.EnShot.rotation);
			//StartCoroutine (EnemyShot ());
		}
		_currentPos = transform.position;
		_currentPos -= new Vector2 (speed, random);
		transform.position = _currentPos;

		if (_currentPos.x <= -9||_currentPos.y>3.65||_currentPos.y<-3.65) {
			Reset ();
		}
	}
	// updates health and bonus when collission occur 
	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject gm = GameObject.Find ("GameManager");
		GameManager gmComponent = gm.GetComponent<GameManager> ();
		PlayerController pl = GameObject.Find("Player").gameObject.GetComponent<PlayerController> ();
		AudioSource audio = gameObject.GetComponent<AudioSource> ();
		if (other.CompareTag ("Player")) {
			if (audio != null) {
				audio.Play (); }
			gmComponent.Health = gmComponent.Health - 20;
			print ("Health: " + gmComponent.Health);
			this.Reset ();
		} 
		if (other.CompareTag ("shot")) {
			gotShots += 1;
			print (gotShots);
			if (3 <= gotShots) {
				if (audio != null) {
					audio.Play (); }
				gmComponent.Health = gmComponent.Health + 10;
				gmComponent.Bonus = gmComponent.Bonus + 10;
				this.Reset ();
			}
		}
		if (other.CompareTag ("shotSuper")) {
			gotShots += 1;
			print (gotShots);
			if (2 <= gotShots) {
				if (audio != null) {
					audio.Play (); }
				gmComponent.Health = gmComponent.Health + 10;
				gmComponent.Bonus = gmComponent.Bonus + 10;
				this.Reset ();
			}
		}
	}

	// instantiate EnemyShot clones at random time
IEnumerator EnemyShot()
	{
			timeShot = Random.Range(2f,5f);
		    yield return new WaitForSeconds(timeShot);
			Instantiate (this.EnShotObj, this.EnShot.position, this.EnShot.rotation);
	}


	// places enemy objects on random positions, resets shots
	private void Reset(){
		this.fireRate=Random.Range (0.5f, 1f);
		random = Random.RandomRange (-0.005f,0.005f);
		float ypos = Random.Range (-2f, 2f);
		float xpos = Random.Range (9f, 30f);
		_currentPos = new Vector2 (xpos, ypos);
		transform.position = _currentPos;
		gotShots = 0;
	}

}
