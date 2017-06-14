using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarnHornCar : MonoBehaviour {

	public AudioClip HornSound;
	private List<MoveCar> Cars = new List<MoveCar>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Car")) {
			var moveCar = other.gameObject.GetComponent<MoveCar> ();
			if (HornSound != null) {
				AudioManager.Instance.PlayClip (HornSound);	
			}
			// para o carro e move novamente depois de 2 segundos
			moveCar.OldSpeed = moveCar.Speed;	
			moveCar.Speed = 0.0f;
			// adiciona o carro a lista
			if (Cars.IndexOf(moveCar) < 0){
				Cars.Add(moveCar);	
			}

			Invoke ("TurnOnCar", 2);
		}
	}

	public void TurnOnCar(){
		var count = Cars.Count; 
		while (count > 0) {
			Cars [count - 1].Speed = Cars [count - 1].OldSpeed;
			Cars.RemoveAt (count - 1);
			count = Cars.Count; 
		}
	}
}
