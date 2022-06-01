using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
	public enum Player
	{
		Magicians,
		Archer,
		Swordsman,
	}

	public Player choosePlayr;
	public Player winner;

	public Menu menu;

	public HealthBar healthBar;
	public int maxHealth = 100;
	public int currentHealth;

	public bool magAlive = true;
	public bool arcAlive = true;
	public bool swoAlive = true;

	bool magarcFlag = false;
	bool magswoFlag = false;
	public Collider2D magiciansHead;
	public Collider2D magiciansFeet;

	bool arcmagFlag = false;
	bool arcswoFlag = false;
	public Collider2D archersHead;
	public Collider2D archersFeet;

	bool swomagFlag = false;
	bool swoarcFlag = false;
	public Collider2D swordsmansHead;
	public Collider2D swordsmansFeet;


	// Start is called before the first frame update
	void Start()
	{
		//Game start health 
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

		//Colliders definitions	
		magiciansHead = GameObject.Find("Magicians").GetComponent<EdgeCollider2D>();
		magiciansFeet = GameObject.Find("Magicians").GetComponent<CircleCollider2D>();
		archersHead = GameObject.Find("Archer").GetComponent<EdgeCollider2D>();
		archersFeet = GameObject.Find("Archer").GetComponent<CircleCollider2D>();
		swordsmansHead = GameObject.Find("Swordsman").GetComponent<EdgeCollider2D>();
		swordsmansFeet = GameObject.Find("Swordsman").GetComponent<CircleCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{
/*
		Debug.Log("Arc ->" + arcAlive);
		Debug.Log("Mag ->" + magAlive);
		Debug.Log("Swo ->" + swoAlive);
*/

		switch (choosePlayr)
		{
			case Player.Magicians:

				if (magiciansHead.IsTouching(archersFeet))
				{
					if(magarcFlag == false) TakeDamage(20);
					magarcFlag = true;
				}
				else
                {
					magarcFlag = false; 
                }

				if (magiciansHead.IsTouching(swordsmansFeet))
				{
					if (magswoFlag == false) TakeDamage(20);
					magswoFlag = true;
				}
				else
				{
					magswoFlag = false;
				}

				if (GameObject.Find("Magicians").transform.position.y < -20)
                {
					StartCoroutine(die());
					magAlive = false;

				}

				if (currentHealth <= 0) magAlive = false;
				
				break;


			case Player.Archer:

				if (archersHead.IsTouching(magiciansFeet))
				{
					if (arcmagFlag == false) TakeDamage(20);
					arcmagFlag = true;
				}
				else
				{
					arcmagFlag = false;
				}

				if (archersHead.IsTouching(swordsmansFeet))
				{
					if (arcswoFlag == false) TakeDamage(20);
					arcswoFlag = true;
				}
				else
				{
					arcswoFlag = false;
				}

				if (GameObject.Find("Archer").transform.position.y < -20)
				{
					arcAlive = false;
					StartCoroutine(die());
				}
					
				if (currentHealth <= 0) arcAlive = false;
				break;

			case Player.Swordsman:

				if (swordsmansHead.IsTouching(magiciansFeet))
				{
					if (swomagFlag == false) TakeDamage(20);
					swomagFlag = true;
				}
				else
				{
					swomagFlag = false;
				}

				if (swordsmansHead.IsTouching(archersFeet))
				{
					if (swoarcFlag == false) TakeDamage(20);
					swoarcFlag = true;
				}
				else
				{
					swoarcFlag = false;
				}

				if (GameObject.Find("Swordsman").transform.position.y < -20)
                {
					StartCoroutine(die());
					swoAlive = false;
				}
					
				if (currentHealth <= 0) swoAlive = false;
				
				break;
		}
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

		if (currentHealth <= 0) StartCoroutine(die());
	}

	IEnumerator die()
    {
		Debug.Log("Sbdy just fucking died!!!");
		healthBar.SetHealth(0);
		GetComponent<CharacterController2D>().enabled = false;
		GetComponent<PlayerMovement>().enabled = false;
		GetComponent<BoxCollider2D>().enabled = false;
		GetComponent<CircleCollider2D>().enabled = false;
		GetComponent<EdgeCollider2D>().enabled = false;
		yield return new WaitForSeconds(4);
		GetComponent<SpriteRenderer>().enabled = false;
		this.enabled = false;
    }
}