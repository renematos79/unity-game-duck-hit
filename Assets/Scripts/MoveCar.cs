using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour {

	public enum MoveCarDirection { Up, Down }
	public MoveCarDirection CarDirection = MoveCarDirection.Up;
	public float Speed = 2.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.CarDirection == MoveCarDirection.Down) {
			this.gameObject.transform.Translate (new Vector2 (0, -1 * Time.deltaTime * this.Speed));
		} else {
			this.gameObject.transform.Translate (new Vector2 (0, Time.deltaTime * this.Speed));
		}
	}
}
