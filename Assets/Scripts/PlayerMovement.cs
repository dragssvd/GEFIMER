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

	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

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

				if (Input.GetButtonDown("MagCrouch"))
				{
					crouch = true;
				}
				else if (Input.GetButtonUp("MagCrouch"))
				{
					crouch = false;
				}

				break;


			case Player.Archer:
				horizontalMove = Input.GetAxisRaw("ArcHorizontal") * runSpeed;
				if (Input.GetButtonDown("ArcJump"))
				{
					jump = true;
				}

				if (Input.GetButtonDown("ArcCrouch"))
				{
					crouch = true;
				}
				else if (Input.GetButtonUp("ArcCrouch"))
				{
					crouch = false;
				}

				break;

			case Player.Swordsman:
				horizontalMove = Input.GetAxisRaw("SwoHorizontal") * runSpeed;
				if (Input.GetButtonDown("SwoJump"))
				{
					jump = true;
				}

				if (Input.GetButtonDown("SwoCrouch"))
				{
					crouch = true;
				}
				else if (Input.GetButtonUp("SwoCrouch"))
				{
					crouch = false;
				}

				break;

		}

	}

	public void IsCrouching(bool isCrouching)
    {
		animator.SetBool("IsCrouching", isCrouching);
    }

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;

	}
}