using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        IInteract object_Hit = collision.gameObject.GetComponent<IInteract>();

        if (object_Hit != null)
        {
            object_Hit.heal(20);

            Destroy(gameObject);

            /*if (object_Hit is vehicle)
            {
                ((vehicle)object_Hit).no_You_see_me();
            }*/
        }
    }
}
