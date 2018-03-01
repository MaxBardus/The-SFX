using UnityEngine;
using System.Collections;

// GameManager.cs
// author: Maksym Bardus
// ID: 100953577
// COMP3064
// Last modified by Maksym Bardus
// Date last modified: Nov26, 2017
// Desciption: GameManager.cs stores number of bonuses collected by player and current health
// Revision 0.1  -  11.26.17  -  class created and all methods are implemented

public class GameManager : MonoBehaviour {
	public int Bonus=0; //bonuses collected by player
	public int Health = 100; //current health
	void Start () {
		AudioSource audio = gameObject.GetComponent<AudioSource> ();
		if (audio != null) {
			audio.Play ();
		}
	}

	void Update () {
	
	}
	// Gui.cs controls the bonus collected by player and counts player's health
	void OnGUI ()
	{
		if (Health >= 0) {
			//  for health 
			GUI.Label (new Rect (15, 10, 200, 50), "<b><color=#53FFD3><size=20>Bonus acuired: " + Bonus + "</size></color></b>");
			GUI.Label (new Rect (Screen.width - 210, 10, Screen.width - 200, 50), "<b><color=#53FFD3><size=20>Health: " + Health + "</size></color></b>");
		}
		 if(Health<0){
            // if you loose
			Time.timeScale = 0;
			GUI.Label (new Rect (Screen.width/4, Screen.height/4, Screen.width - Screen.width/4, Screen.height - Screen.height/4), "<b><color=red><size=50>Seems like you lost. Game Over :(</size></color></b>");
	}
		if (Bonus >= 200 & Health > 0) {
            // if you win
			Time.timeScale = 0;
			GUI.Label (new Rect (Screen.width/4, Screen.height/4, Screen.width - Screen.width/4, Screen.height - Screen.height/4), "<b><color=red><size=50>Congratulation! You won!</size></color></b>");
		}
}
}