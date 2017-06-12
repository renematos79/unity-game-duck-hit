using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerOrderInLayer : MonoBehaviour {

	public int ApplyOrderLayout = 0;
	public int ApplyOrderLayouOut = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			var playerRender = other.gameObject.GetComponent<SpriteRenderer> ();
			playerRender.sortingOrder = this.ApplyOrderLayout;
		}
	}

	public void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			var playerRender = other.gameObject.GetComponent<SpriteRenderer> ();
			playerRender.sortingOrder = this.ApplyOrderLayouOut;	
		}
	}


}
