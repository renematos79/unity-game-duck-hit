using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	public float Speed = 2.5f;
	public AudioClip GameOverSound;
	private Animator Anim;

	// Use this for initialization
	void Start () {
		Anim = this.gameObject.GetComponent<Animator> ();
	}

	KeyCode GetSelectedKey(){
		if (Input.GetKey (KeyCode.UpArrow)) {
			return KeyCode.UpArrow;
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			return KeyCode.DownArrow;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			return KeyCode.LeftArrow;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			return KeyCode.RightArrow;
		}

		return KeyCode.O;
	}

	// Update is called once per frame
	void Update () {
		var local = this.gameObject.transform.localScale;
		var idle = true;
		var keycode = GetSelectedKey ();


		if (keycode == KeyCode.UpArrow) {
			if (ButtomFunctions.KeyboardType == ButtomFunctions.KeyboardOptions.Keyboard) {
				this.gameObject.transform.Translate (new Vector2 (0, Time.deltaTime * this.Speed));	
			}
			if (ButtomFunctions.KeyboardType == ButtomFunctions.KeyboardOptions.Accelerometer) {
				this.gameObject.transform.Translate (new Vector2 (0, Input.acceleration.x * Time.deltaTime * this.Speed));	
			}

			idle = false;
			ChangeToMovement ();
		} 

		if (keycode == KeyCode.DownArrow) {
			if (ButtomFunctions.KeyboardType == ButtomFunctions.KeyboardOptions.Keyboard) {
				this.gameObject.transform.Translate (new Vector2 (0, -1 * Time.deltaTime * this.Speed));
			}
			if (ButtomFunctions.KeyboardType == ButtomFunctions.KeyboardOptions.Accelerometer) {
				this.gameObject.transform.Translate (new Vector2 (0, Input.acceleration.x * Time.deltaTime * this.Speed));
			}

			idle = false;
			ChangeToMovement ();
		} 

		if (keycode == KeyCode.LeftArrow) {
			if (ButtomFunctions.KeyboardType == ButtomFunctions.KeyboardOptions.Keyboard) {
				this.gameObject.transform.Translate (new Vector2 (-1 * Time.deltaTime * this.Speed, 0));
			}
			if (ButtomFunctions.KeyboardType == ButtomFunctions.KeyboardOptions.Accelerometer) {
				this.gameObject.transform.Translate (new Vector2 (Input.acceleration.y * Time.deltaTime * this.Speed, 0));
			}

			if (local.x < 0) local.x *= -1;
			idle = false;
			ChangeToMovement ();
		} 

		if (keycode == KeyCode.RightArrow) {
			if (ButtomFunctions.KeyboardType == ButtomFunctions.KeyboardOptions.Keyboard) {
				this.gameObject.transform.Translate (new Vector2 (Time.deltaTime * this.Speed, 0));
			}
			if (ButtomFunctions.KeyboardType == ButtomFunctions.KeyboardOptions.Accelerometer) {
				this.gameObject.transform.Translate (new Vector2 (Input.acceleration.y * Time.deltaTime * this.Speed, 0));
			}

			if (local.x > 0) local.x *= -1;
			idle = false;
			ChangeToMovement ();
		} 

		if (idle) {
			ChangeToIdle ();
		}			

		this.gameObject.transform.localScale = local;

	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Car")) {
			AudioManager.Instance.PlayClip (GameOverSound);
			//DestroyObject (this.gameObject);	
			ChangeToDeath();
			Time.timeScale=0;
		}
	}

	private void ChangeToDeath(){
		Anim.SetBool ("death", true);
		Anim.SetBool ("idle", false);
		Anim.SetBool ("movement", false);
	}

	private void ChangeToMovement(){
		Anim.SetBool ("death", false);
		Anim.SetBool ("idle", false);
		Anim.SetBool ("movement", true);
	}

	private void ChangeToIdle(){
		Anim.SetBool ("death", false);
		Anim.SetBool ("idle", true);
		Anim.SetBool ("movement", true);
	}
}
