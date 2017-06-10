using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityStripCollision : MonoBehaviour {

	public GameObject Semaphore = null;
	private Animator Anim = null;

	// Use this for initialization
	void Start () {
		if (Semaphore != null) {
			this.Anim = Semaphore.GetComponent<Animator> ();	
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Car" && Anim != null) {
			var moveCar = other.gameObject.GetComponent<MoveCar> ();
			if (Anim.GetBool ("Red") == false) {
				moveCar.Speed = moveCar.OldSpeed;	
			} else {
				moveCar.OldSpeed = moveCar.Speed;	
				moveCar.Speed = 0.0f;
			}
		}
	}
}
