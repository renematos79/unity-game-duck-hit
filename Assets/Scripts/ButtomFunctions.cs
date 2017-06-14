using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtomFunctions : MonoBehaviour {

	public enum KeyboardOptions {Keyboard, Accelerometer, Joystick}

	public UnityEngine.UI.Toggle Sound;
	public UnityEngine.UI.Dropdown Keyboard;

	public static bool SoundOn = true;
	public static KeyboardOptions KeyboardType = KeyboardOptions.Keyboard;
	public static int KeyboardValue = 0;

	// Use this for initialization
	void Start () {
		this.Sound.isOn = ButtomFunctions.SoundOn;
		this.Keyboard.value = ButtomFunctions.KeyboardValue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NewGame(){
		SceneManager.LoadScene("Infantil", LoadSceneMode.Single);
	}

	public void Settings(){
		SceneManager.LoadScene("Settings", LoadSceneMode.Single);
	}

	public void LoadMenu(){
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}

	public void SaveSettings(){
		ButtomFunctions.SoundOn = this.Sound.isOn;
		ButtomFunctions.KeyboardValue = this.Keyboard.value;
		if (this.Keyboard.value == 0) {
			ButtomFunctions.KeyboardType = KeyboardOptions.Keyboard;
		} else if (this.Keyboard.value == 1) {
			ButtomFunctions.KeyboardType = KeyboardOptions.Accelerometer;
		} else {
			ButtomFunctions.KeyboardType = KeyboardOptions.Joystick;
		}

		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}

	public void Quit(){
		Application.Quit();
	}


}
