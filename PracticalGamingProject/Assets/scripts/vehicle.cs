using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicle : MonoBehaviour, IInteract
{

	internal Manager theManager;

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;

	// Start is called before the first frame update
	void Start()
	{
		theManager = FindObjectOfType<Manager>();

		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	// Update is called once per frame
	void Update()
	{
		if (currentHealth <= 0) {
			print("Game Over - You Died");
			theManager.GameOver();
		}
	}

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
}
