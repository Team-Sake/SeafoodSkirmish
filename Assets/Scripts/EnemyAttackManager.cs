using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    public Transform hitboxPointLeft;
    public Transform hitboxPointRight;
    public GameObject hitboxPrefab;
    public GameObject activeHitbox;
    public float hitBoxDamage;
    public void CreateHitboxLeft()
    {
        activeHitbox = Instantiate(hitboxPrefab, hitboxPointLeft.position, transform.rotation);
        activeHitbox.GetComponent<Hitbox>().SetDamage(hitBoxDamage);
    }
    
    public void CreateHitboxRight()
    {
        activeHitbox = Instantiate(hitboxPrefab, hitboxPointRight.position, transform.rotation);
        activeHitbox.GetComponent<Hitbox>().SetDamage(hitBoxDamage);
    }

    public void DestroyHitbox()
    {
        Destroy(activeHitbox);
    }
}
