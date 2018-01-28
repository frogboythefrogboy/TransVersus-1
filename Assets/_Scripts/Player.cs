﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Player : MonoBehaviour {

	public int playerID;
	public Rewired.Player player;

	public bool isJumping;
	public bool isAttacking;
	public float playerMovement;

	public bool isStunned;
	private float stunnedTime = 2f;
	private float stunnedTimer;

	public Sprite regularSprite;
	public Sprite stunnedSprite;
	public Sprite holdingBallSprite;

	public bool hasBall;

	public enum PlayerID
	{
		PlayerOne, PlayerTwo, PlayerThree, PlayerFour
	}

	public enum Team
	{
		Red, Blue
	}

	public PlayerID thisPlayer;
	public Team playerTeam;

	public UnityStandardAssets._2D.PlatformerCharacter2D characterController;
//	public NinjaController.NinjaController playerController;

	public Weapon weapon;

	void Awake () {
		player = ReInput.players.GetPlayer (playerID);
		weapon = GetComponentInChildren<Weapon> ();
		characterController = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D> ();
	}
	
	void Update () 
	{
		isJumping = player.GetButtonDown ("Jump");
		isAttacking = player.GetButtonDown ("Attack");

		playerMovement = player.GetAxisRaw ("Move Horizontal");
		if (isStunned) 
		{
			playerMovement = 0f;
		}

		if (isJumping)
		{
			MusicManager.instance.PlaySFX (MusicManager.instance.jumpClip);
//			Debug.Log (this.name + " is Jumping!!!");
		}

		if (isAttacking) {
			Debug.Log (this.name + " is Attacking!!!");
			MusicManager.instance.PlaySFX (MusicManager.instance.hitClip);
			weapon.gameObject.SetActive (true);
		} 

		if (stunnedTimer > 0) {
			stunnedTimer -= Time.deltaTime;
		} 
		else 
		{
			isStunned = false;
		}


	}

	public void GetStunned()
	{
		isStunned = true;
		stunnedTimer = stunnedTime;
	}



}
