using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovePlayerMascote : MonoBehaviour {

	public enum PlayerAnimationState
	{
		Idle, Up, Down, Left, Right, Death
	}

	private PlayerAnimationState State = PlayerAnimationState.Idle;
	private Animator Anim;
	public float Speed = 1.25f;
	public AudioClip GameOverSound;
	public int Coins = 0;

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
		if (Input.GetKey (KeyCode.UpArrow)) {
			if (InState (PlayerAnimationState.Up) == false) {
				ChangeState (PlayerAnimationState.Up);	
			}
			MovePlayer (PlayerAnimationState.Up);
		} 
		#endregion 

		#region .: down :.
		if (Input.GetKey (KeyCode.DownArrow)) {
			if (InState (PlayerAnimationState.Down) == false) {
				ChangeState (PlayerAnimationState.Down);	
			}
			MovePlayer (PlayerAnimationState.Down);
		}
		#endregion

		#region .: left :.
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (InState (PlayerAnimationState.Left) == false) {
				ChangeState (PlayerAnimationState.Left);	
			}
			MovePlayer (PlayerAnimationState.Left);
		}
		#endregion

		#region .: right :.
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (InState (PlayerAnimationState.Right) == false) {
				ChangeState (PlayerAnimationState.Right);	
			}
			MovePlayer (PlayerAnimationState.Right);
		}
		#endregion 
	}

	private bool InState(params PlayerAnimationState[] states)
	{
		return states.ToList().Contains (State);
	}

	private void MovePlayer(PlayerAnimationState state)
	{
		ChangeState (state);
		switch (state) 
		{
			case PlayerAnimationState.Up:
			{
				var delta = Time.deltaTime * this.Speed;
				this.gameObject.transform.Translate (new Vector2 (0, delta));
				break;
			}
			case PlayerAnimationState.Down:
			{
				var delta = Time.deltaTime * this.Speed * -1;
				this.gameObject.transform.Translate (new Vector2 (0, delta));
				break;
			}
			case PlayerAnimationState.Left:
			{
				var delta = Time.deltaTime * this.Speed * -1;
				this.gameObject.transform.Translate (new Vector2 (delta, 0));
				var local = this.gameObject.transform.localScale;
				if (local.x < 0) {
					local.x *= -1;
					this.gameObject.transform.localScale = local;
				}
				break;
			}
			case PlayerAnimationState.Right:
			{
				var delta = Time.deltaTime * this.Speed;
				this.gameObject.transform.Translate (new Vector2 (delta, 0));
				var local = this.gameObject.transform.localScale;
				if (local.x > 0) {
					local.x *= -1;
					this.gameObject.transform.localScale = local;
				}
				break;
			}		
		}

	}

	public void ChangeState(PlayerAnimationState state)
	{
		this.Anim.SetBool ("Idle", state == PlayerAnimationState.Idle);
		this.State = state;
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
