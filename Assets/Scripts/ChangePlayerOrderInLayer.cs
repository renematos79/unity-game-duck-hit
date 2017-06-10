using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerOrderInLayer : MonoBehaviour {

	public int OrderInLayer = 7;
	public int OrderOutLayer = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			var spriteRender = other.gameObject.GetComponent<SpriteRenderer> ();
			if (spriteRender != null) {
				spriteRender.sortingOrder = this.OrderInLayer;
			}
		}
	}

	public void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			var spriteRender = other.gameObject.GetComponent<SpriteRenderer> ();
			if (spriteRender != null) {
				spriteRender.sortingOrder = this.OrderOutLayer;
			}
		}
	}
}
