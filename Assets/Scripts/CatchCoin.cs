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
			var player = other.gameObject.GetComponent<MovePlayerMascote> ();
			player.Coins++;
			if (this.CatchCoinAudioClip != null) {
				AudioManager.Instance.PlayClip (this.CatchCoinAudioClip);	
			}
			Coins.text = player.Coins.ToString ();
			Destroy (this.gameObject);
			//UpdateCoins(this.Coins+1);
		}	
	}
}
