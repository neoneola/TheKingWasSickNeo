﻿using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {

	public float maxSpeed = 15.0f;

	private bool facingRight = true;

	public bool hitAwall = false;
	public bool hitRight = false;
	public bool hitLeft = false;

	private Servant servant;
	private King king;
	void Awake(){
		servant = GameObject.FindGameObjectWithTag(Tags.SERVANT).GetComponent<Servant>();
		king = GameObject.FindGameObjectWithTag(Tags.KING).GetComponent<King>();
	}

	// Use this for initialization
	void Start () {
	
	}

	/// <summary>
	/// deal with input.
	/// </summary>
	void FixedUpdate(){

	}

	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		move(h);
	}

	// handler
	public void setHitInfo(bool _hitAwall){
		hitAwall = _hitAwall;
		if(hitAwall){
			if(facingRight){
				hitRight = true;
			}else{
				hitLeft = true;
			}
		}else{
			hitLeft = hitRight = false;
		}
	}

	private void move(float horizontal){

		if(hitAwall){
			if(facingRight){
				if(hitRight){
					horizontal = horizontal > 0 ? 0 : horizontal;
				}
			}
			if(!facingRight){
				if(hitLeft){
					horizontal = horizontal < 0 ? 0 : horizontal;
				}
			}
		}

		if(Mathf.Abs(horizontal) >= 0.01){
			if(ThroneGameController.currentChar == "Servant"){
				servant.walk();
			}

			if(ThroneGameController.currentChar == "King"){
				king.walk();
			}
		}else{
			if(ThroneGameController.currentChar == "Servant"){
				servant.stopWalk();
			}

			if(ThroneGameController.currentChar == "King"){
				king.stopWalk();
			}
		}

		// Move the character
		//rigidbody2D.velocity = new Vector2(horizontal * maxSpeed, rigidbody2D.velocity.y);
		transform.Translate(new Vector2(horizontal * maxSpeed * Time.deltaTime, rigidbody2D.velocity.y));
		// If the input is moving the player right and the player is facing left...
		if(horizontal > 0 && !facingRight)
			// ... flip the player.
			flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(horizontal < 0 && facingRight)
			// ... flip the player.
			flip();
	}

	/// <summary>
	/// Flip this instance.
	/// </summary>
	private void flip(){
		facingRight = !facingRight;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
