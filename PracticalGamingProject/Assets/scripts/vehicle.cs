using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicle : MonoBehaviour, IDamagable
{

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
		//if (Input.GetKeyDown(KeyCode.H))
		//{
		//	TakeDamage(20);
		//}
	}

	//void TakeDamage(int damage)
	//{
	//	currentHealth -= damage;

	//	healthBar.SetHealth(currentHealth);
	//}

    public void take_Damage(int amountDam)
    {
		currentHealth -= amountDam;

		healthBar.SetHealth(currentHealth);
	}
	public void heal(int amountHeal)
	{
		currentHealth += amountHeal;

		healthBar.SetHealth(currentHealth);
	}

	internal void no_You_see_me()
    {
		print("You see me");
    }
}
