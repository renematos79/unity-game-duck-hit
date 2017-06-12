using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovePlayerDuck : MonoBehaviour {

	public enum PlayerAnimationState
	{
		Up, MoveUp, Down, MoveDown, Left, MoveLeft, Right, MoveRight, Death
	}

	private PlayerAnimationState State = PlayerAnimationState.Right;
	private Animator Anim;
	private List<PlayerAnimationState> States = new List<PlayerAnimationState>
	{
		PlayerAnimationState.Up, 
		PlayerAnimationState.MoveUp, 
		PlayerAnimationState.Down, 
		PlayerAnimationState.MoveDown, 
		PlayerAnimationState.Left, 
		PlayerAnimationState.MoveLeft, 
		PlayerAnimationState.Right, 
		PlayerAnimationState.MoveRight, 
		PlayerAnimationState.Death
	};

	public float Speed = 2.5f;
	public AudioClip CarExplosion;
	public AudioClip GameOverSound;

	// Use this for initialization
	void Start () {
		Anim = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (State == PlayerAnimationState.Death) {
			return;
		}

		#region .: up :.
		if (Input.GetKeyUp(KeyCode.UpArrow)) {
			ChangeState (PlayerAnimationState.Up);	
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			if (InState (PlayerAnimationState.Up, PlayerAnimationState.MoveUp) == false) {
				ChangeState (PlayerAnimationState.Up);	
			}
			MovePlayer (PlayerAnimationState.MoveUp);
		} 
		#endregion 

		#region .: down :.
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			ChangeState (PlayerAnimationState.Down);	
		} 

		if (Input.GetKey (KeyCode.DownArrow)) {
			if (InState (PlayerAnimationState.Down, PlayerAnimationState.MoveDown) == false) {
				ChangeState (PlayerAnimationState.Down);	
			}
			MovePlayer (PlayerAnimationState.MoveDown);
		}
		#endregion

		#region .: left :.
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			ChangeState (PlayerAnimationState.Left);	
		} 

		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (InState (PlayerAnimationState.Left, PlayerAnimationState.MoveLeft) == false) {
				ChangeState (PlayerAnimationState.Left);	
			}
			MovePlayer (PlayerAnimationState.MoveLeft);
		}
		#endregion

		#region .: right :.
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			ChangeState (PlayerAnimationState.Right);	
		} 

		if (Input.GetKey (KeyCode.RightArrow)) {
			if (InState (PlayerAnimationState.Right, PlayerAnimationState.MoveRight) == false) {
				ChangeState (PlayerAnimationState.Right);	
			}
			MovePlayer (PlayerAnimationState.MoveRight);
		}
		#endregion 
	}

	private bool InState(params PlayerAnimationState[] states)
	{
		return states.ToList().Contains (State);
	}

	private string StateToString(PlayerAnimationState state)
	{
		switch (state) 
		{
			case PlayerAnimationState.Up:
				return "up";
			case PlayerAnimationState.MoveUp:
				return "move-up";
			case PlayerAnimationState.Down:
				return "down";
			case PlayerAnimationState.MoveDown:
				return "move-down";
			case PlayerAnimationState.Left:
				return "left";
			case PlayerAnimationState.MoveLeft:
				return "move-left";
			case PlayerAnimationState.Right:
				return "right";
			case PlayerAnimationState.MoveRight:
				return "move-right";
			default: 
				return "die";
		}
	}

	private void MovePlayer(PlayerAnimationState state)
	{
		ChangeState (state);
		switch (state) 
		{
			case PlayerAnimationState.MoveUp:
				{
					this.gameObject.transform.Translate (new Vector2 (0, +1 * Time.deltaTime * this.Speed));
					break;
				}
			case PlayerAnimationState.MoveDown:
				{
					this.gameObject.transform.Translate (new Vector2 (0, -1 * Time.deltaTime * this.Speed));
					break;
				}
			case PlayerAnimationState.MoveLeft:
				{
					this.gameObject.transform.Translate (new Vector2 (-1 * Time.deltaTime * this.Speed, 0));
					break;
				}
			case PlayerAnimationState.MoveRight:
				{
					this.gameObject.transform.Translate (new Vector2 (+1 * Time.deltaTime * this.Speed, 0));
					break;
				}		
		}

	}

	public void ChangeState(PlayerAnimationState state)
	{
		// zera todos os valores disponiveis pelo enum
		States.ForEach(s=>
		{
			this.Anim.SetBool(StateToString(s), false);
		});
		this.Anim.SetBool (StateToString(state), true);
		this.State = state;
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Car")) {
			if (this.CarExplosion != null) {
				var scale = other.gameObject.transform.localScale;
				scale.x = 0.2f;
				scale.y = 0.2f;
				other.gameObject.transform.localScale = scale;
				other.gameObject.GetComponent<Animator> ().SetBool ("blow", true);
				AudioManager.Instance.PlayClip (this.CarExplosion);	
				var moveCar = other.gameObject.GetComponent<MoveCar> ();
				moveCar.CarDirection = MoveCar.MoveCarDirection.None;

				// muda o status do jogador para morto
				ChangeState (PlayerAnimationState.Death);

				// para a criacao de carros
				var scriptCreateCar = Camera.main.GetComponent<CreateCar> ();
				scriptCreateCar.enabled = false;
				scriptCreateCar.StopCreateCar = true;
					
				Delay(3, () => {
					// destroi o carro
					DestroyObject (other.gameObject);


					// play sound game over
					if (this.GameOverSound != null) {
						AudioManager.Instance.PlayClip (this.GameOverSound);
						this.GameOverSound = null;
					}

					// desliga a visao game
					//Camera.main.cullingMask = 1 << LayerMask.NameToLayer("Nothing");
					//Camera.main.cullingMask = 1 << LayerMask.NameToLayer("UI");
				} );
			}

			//DestroyObject (this.gameObject);	
			//Time.timeScale=0;
		}
	}

	void Delay( float waitTime, Action act )
	{
		StartCoroutine( DelayImpl( waitTime, act ) );
	}

	IEnumerator DelayImpl( float waitTime, Action act )
	{
		yield return new WaitForSeconds( waitTime );
		act();
	}
}
