using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SemaphoreControl : MonoBehaviour {

	public bool IsRed = true;
	public float Time = 2.0f;
	public float RepeatTime = 3.0f;

	private Animator Anim;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("ChangeColor", this.Time, this.RepeatTime);
		Anim = GetComponent<Animator> ();
		ChangeColor ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MoveAllCars(){
		var objs = UnityEngine.Object.FindObjectsOfType<GameObject>();
		var cars = objs.Where (s => s.tag.Equals("Car")).ToList(); 
		if (cars != null) {
			foreach (var car in cars) {
				var moveCar = car.gameObject.GetComponent<MoveCar> ();
				moveCar.Speed = moveCar.OldSpeed;
			}
		}
	}

	void ChangeColor(){
		if (this.IsRed) {
			Anim.SetBool ("Red", false);
			MoveAllCars ();
		} else {
			Anim.SetBool ("Red", true);
		}
		this.IsRed = !IsRed;
	}

}
