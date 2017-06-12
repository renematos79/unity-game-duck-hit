using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour {

	public enum MoveCarDirection { Up, Down, Left, Right, None }
	public MoveCarDirection CarDirection = MoveCarDirection.Up;
	public float Speed = 2.5f;
	public float OldSpeed = 2.5f;
	public GameObject SmokeParticle;

	// Use this for initialization
	void Start () {
		if (this.SmokeParticle != null) {
			InvokeRepeating ("CreateSmokeParticle", 2.0f, 2.0f);
		}
	}

	private void CreateSmokeParticle(){
		var smoke = Instantiate (SmokeParticle);
		smoke.gameObject.transform.parent = this.transform.parent;
		smoke.transform.position = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (this.CarDirection == MoveCarDirection.None) {
			return;
		}

		if (this.CarDirection == MoveCarDirection.Down) {
			this.gameObject.transform.Translate (new Vector2 (0, -1 * Time.deltaTime * this.Speed));
		} else if (this.CarDirection == MoveCarDirection.Up) {
			this.gameObject.transform.Translate (new Vector2 (0, Time.deltaTime * this.Speed));
		} else if (this.CarDirection == MoveCarDirection.Left) {
			this.gameObject.transform.Translate (new Vector2 (-1 * Time.deltaTime * this.Speed, 0));
		} else {
			this.gameObject.transform.Translate (new Vector2 (Time.deltaTime * this.Speed, 0));
		}
	}
}
