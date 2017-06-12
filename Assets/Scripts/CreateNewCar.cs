using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class CreateNewCar : MonoBehaviour {

	public GameObject Coord;
	public GameObject CarType;
	public float Time = 5.0f;
	public float RepeatTime = 2.0f;
	public bool StopCreatingCar = false;
	public float Speed = 3.0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateCarAtPosition", this.Time, this.RepeatTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateCarAtPosition(){
		if (StopCreatingCar == true) {
			return;
		}
		if (Coord == null) {
			return;
		}
		if (CarType == null) {
			return;
		}
		// verifica se ja existe algum carro do tipo informado criado na janela
		var objs = UnityEngine.Object.FindObjectsOfType<GameObject>();
		var objsType = objs.Where (s => s.name.ToUpper().Contains(CarType.name.ToUpper())); 
		if (objsType.Any()) {
			return;
		}

		var cpp = this.Coord.GetComponent<CarPointPosition>();
		var car = Instantiate (CarType);
		car.transform.position = cpp.transform.position;
		car.gameObject.transform.parent = this.Coord.transform;

		var carInstance = car.GetComponent<MoveCar> ();
		carInstance.CarDirection = cpp.CarDirection;
		carInstance.Speed = this.Speed;
		carInstance.OldSpeed = this.Speed;
	}
}
