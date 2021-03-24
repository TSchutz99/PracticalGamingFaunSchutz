using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    void take_Damage(int amountDam);

    void heal(int amountHeal);
}
