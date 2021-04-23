using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkit : PowerPacks
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    internal void Update()
    {
        base.Update();
    }
    private void OnCollisionEnter(Collision collision)
    {
        IInteract object_Hit = collision.gameObject.GetComponent<IInteract>();

        if (object_Hit != null)
        {
            object_Hit.heal(20);

            theManager.IveBeenDestroyed(this);
            Destroy(gameObject);

            /*if (object_Hit is vehicle)
            {
                ((vehicle)object_Hit).no_You_see_me();
            }*/
        }
    }
}
