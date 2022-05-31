using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public enum Player
	{
		Magicians,
		Archer,
		Swordsman,
	}

	public Player choosePlayr;

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	// Update is called once per frame
	void Update()
	{
		switch (choosePlayr)
		{
			case Player.Magicians:

				if (Input.GetButtonDown("MagJump"))
				{
					TakeDamage(20);
				}

				break;


			case Player.Archer:
				if (Input.GetButtonDown("ArcJump"))
				{
					TakeDamage(20);
				}

				break;

			case Player.Swordsman:
				if (Input.GetButtonDown("SwoJump"))
				{
					TakeDamage(20);
				}

				break;

		}

	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}