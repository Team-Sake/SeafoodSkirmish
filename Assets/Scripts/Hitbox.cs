using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damage;
    public void SetDamage(float damageAmount)
    {
        damage = damageAmount;
    }
    public float GetDamage()
    {
        return damage;
    }
}
