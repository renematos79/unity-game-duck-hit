using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCar : MonoBehaviour {

	// lista de objetos que serao usados como coordenadas iniciais para os carros
	public List<GameObject> SourceCoords;
	// lista de prefabs que sera usada para criar os tipos de carros
	public List<GameObject> SourceCars;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateCarAtPosition", 5.0f, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private GameObject GetCar(){
		if (SourceCars == null || SourceCars.Count == 0) {
			return null;
		}
		var parts = 1.0f / (float)SourceCars.Count;
		var sort = Random.value;
		var count = 0;
		while (sort <= parts && parts <= 1.0) {
			count++;
			parts += parts;
		}
		return SourceCars[count];
	}

	void CreateCarAtPosition(){
		foreach (var sc in SourceCoords) {
			var cpp = sc.GetComponent<CarPointPosition> ();
			var carType = GetCar ();
			if (carType != null) {
				var obj = Instantiate (carType);
				obj.transform.position = cpp.transform.position;
				var mvCar = obj.GetComponent<MoveCar> ();
				mvCar.CarDirection = cpp.CarDirection;
				var local = mvCar.gameObject.transform.localScale;
				if (mvCar.CarDirection == MoveCar.MoveCarDirection.Down) {
					local.y = -1;
				} else {
					local.y = +1;
				}
				mvCar.gameObject.transform.localScale = local;
			}
		}

		//float y = 10.0f * Random.value - 5;
		//var enemy = Instantiate (Enemy);
		//enemy.transform.position = new Vector2 (10.0f, y);
	}
}
