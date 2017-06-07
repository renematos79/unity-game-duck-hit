using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderColision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other) {
		print ("OnTriggerEnter2D");
		if (other.gameObject.CompareTag ("Car")) {
			DestroyObject (other.gameObject);	
		}
	}
}
