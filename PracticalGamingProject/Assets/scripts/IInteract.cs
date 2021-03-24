using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract 
{
    void take_Damage(int amountDam);

    void heal(int amountHeal);
}
