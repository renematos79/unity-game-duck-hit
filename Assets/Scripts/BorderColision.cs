using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderColision : MonoBehaviour {

	public enum BorderColistionEnumAction
	{
		Destroy, BlockVertical, BlockHorizontal, None
	}

	public string CollideWithTagName;
	public BorderColistionEnumAction ColistionEnumAction = BorderColistionEnumAction.None;
	public float Offset = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other) {
		//print ("OnTriggerEnter2D");
		if (other.gameObject.CompareTag (this.CollideWithTagName)) {
			switch (ColistionEnumAction) {
				case BorderColistionEnumAction.Destroy:
				{
					DestroyObject (other.gameObject);
					return;
				}
				case BorderColistionEnumAction.BlockVertical:
				{
					var tagPosition = other.gameObject.transform.position;
					tagPosition.y = this.gameObject.transform.position.y + Offset;
					other.gameObject.transform.position = tagPosition;
					return;
				}
				case BorderColistionEnumAction.BlockHorizontal:
				{
					var tagPosition = other.gameObject.transform.position;
					tagPosition.x = this.gameObject.transform.position.x + Offset;
					other.gameObject.transform.position = tagPosition;
					return;
				}
			}
		}
	}
}
