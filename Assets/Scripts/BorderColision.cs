using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderColision : MonoBehaviour {

	public enum BorderColistionEnumAction
	{
		Destroy, Block, Nothing
	}

	public string CollideWithTagName;
	public BorderColistionEnumAction ColistionEnumAction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other) {
		//print ("OnTriggerEnter2D");
		if (other.gameObject.CompareTag (this.CollideWithTagName)) {
			if (ColistionEnumAction == BorderColistionEnumAction.Destroy)
				DestroyObject (other.gameObject);	
		}
	}
}
