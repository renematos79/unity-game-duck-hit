using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceSound : MonoBehaviour {

	public AudioClip Sound;

	// Use this for initialization
	void Start () {
		AudioManager.Instance.PlayClip (Sound);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
