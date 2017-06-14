using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour {

	public AudioClip CatchCoinAudioClip;
	public AudioClip GameOverClip;
	public UnityEngine.UI.Text Coins;
	public UnityEngine.UI.Text PlayerCoins;
	public int CoinsAmount = 0;
	public GameObject GameOverPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySound(){
		AudioManager.Instance.PlayClip (this.CatchCoinAudioClip);
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			var animator = this.gameObject.GetComponent<Animator> ();
			animator.SetBool ("Open", true);
			var player = other.gameObject.GetComponent<MovePlayerMascote> ();
			if (player.Coins > 0) {
				CoinsAmount += player.Coins;
				if (this.CatchCoinAudioClip != null) {
					for (int i = 1; i <= player.Coins; i++) {
						Invoke ("PlaySound", i*0.2f);
					}
				}
				player.Coins = 0;
				PlayerCoins.text = "0";
				Coins.text = CoinsAmount.ToString ();
				// verifica se houve fim de jogo
				if (CoinsAmount >= 5){

					// desliga a musica principal
					Camera.main.GetComponent<AudioSource> ().Stop ();

					// play sound game over
					if (this.GameOverClip != null) {
						AudioManager.Instance.PlayClip (this.GameOverClip);
					}

					// desliga a visao game
					//Camera.main.cullingMask = 1 << LayerMask.NameToLayer("Nothing");
					//Camera.main.cullingMask = 1 << LayerMask.NameToLayer("UI");
					GameOverPanel.SetActive(true);

					Time.timeScale = 0;

				}
			}
		}
	}

	public void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			var animator = this.gameObject.GetComponent<Animator> ();
			animator.SetBool ("Open", false);
		}
	}
}
