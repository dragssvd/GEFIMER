using UnityEngine;



public class PlayerCollision : MonoBehaviour
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
/*
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
*/
	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

	//Detect collisions between the GameObjects with Colliders attached
	void OnCollisionEnter2D(Collision2D collision)
    {
        
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Archer")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Hit Archer");
			TakeDamage(20);
            
        }

        if (collision.gameObject.name == "Magicians")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Magicians");
        }

        if (collision.gameObject.name == "Swordsman")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Hit Swordsman");
        }


        /*
                //Check for a match with the specific tag on any GameObject that collides with your GameObject

                if (collision.gameObject.tag == "Player")
                {
                    //If the GameObject has the same tag as specified, output this message in the console
                    Debug.Log("Do something else here");
                }
        */
    }


}