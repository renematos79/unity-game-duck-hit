using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCoin : MonoBehaviour {

	public AudioClip CatchCoinAudioClip;
	public UnityEngine.UI.Text Coins;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			if (this.CatchCoinAudioClip != null) {
				AudioManager.Instance.PlayClip (this.CatchCoinAudioClip);	
				var total = int.Parse (Coins.text) + 1;
				Coins.text = total.ToString ();
			}
			Destroy (this.gameObject);
			//UpdateCoins(this.Coins+1);
		}	
	}
}
