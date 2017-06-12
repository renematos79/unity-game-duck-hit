using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("RemoveGameObject", 1.5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void RemoveGameObject(){
		DestroyObject (this.gameObject);
	}
}
