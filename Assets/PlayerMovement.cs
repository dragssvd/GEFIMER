using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public enum Player
	{
		Magicians,
		Archer,
		Swordsman,
	}

	public Player choosePlayr;

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;

	//bool crouch = false;

	// Update is called once per frame
	void Update()
	{
		switch (choosePlayr)
		{
			case Player.Magicians:
				horizontalMove = Input.GetAxisRaw("MagHorizontal") * runSpeed;
				if (Input.GetButtonDown("MagJump"))
				{
					jump = true;
				}
				break;

			case Player.Archer:
				horizontalMove = Input.GetAxisRaw("ArcHorizontal") * runSpeed;
				if (Input.GetButtonDown("ArcJump"))
				{
					jump = true;
				}
				break;

			case Player.Swordsman:
				horizontalMove = Input.GetAxisRaw("SwoHorizontal") * runSpeed;
				if (Input.GetButtonDown("SwoJump"))
				{
					jump = true;
				}
				break;

		}
		//Debug.Log(Input.GetAxisRaw("Horizontal");

		/*
		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
		*/

	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;

	}
}