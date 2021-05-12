using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldenEgg : PowerPacks
{
    internal Collected_Eggs eggs;
    int collected_eggs = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        eggs = FindObjectOfType<Collected_Eggs>();
    }

    // Update is called once per frame
    void Update()
    {
        if(collected_eggs == 6)
        {
            print("Game Over - You Win");
            theManager.GameOver();
        }
        else
            base.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IInteract object_Hit = collision.gameObject.GetComponent<IInteract>();

        if (object_Hit != null)
        {
            // After 1 counter dones not go up, no idea why
            collected_eggs++;
            print(collected_eggs);
            eggs.egg_collected(collected_eggs);

            theManager.IveBeenDestroyed(this);
            Destroy(gameObject);
        }
    }
}
