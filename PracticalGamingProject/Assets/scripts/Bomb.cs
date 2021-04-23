using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : PowerPacks
{
    vehicleControl playerLock;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    internal void Update()
    {
        if(playerLock)
        {
            Vector3 dir = (playerLock.transform.position - transform.position).normalized;

            rb.AddForce(dir);
        }
        else
            base.Update();
    }
    private void OnCollisionEnter(Collision collision)
    {
        IInteract object_Hit = collision.gameObject.GetComponent<IInteract>();

        if (object_Hit != null)
        {
            object_Hit.take_Damage(20);

            theManager.IveBeenDestroyed(this);
            Destroy(gameObject);

            /*if (object_Hit is vehicle)
            {
                ((vehicle)object_Hit).no_You_see_me();
            }*/
        }
    }

    internal void lockOn(vehicleControl player)
    {
        playerLock = player;
    }
}
