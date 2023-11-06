using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public Transform hitboxPoint;  
    public GameObject hitboxPrefab;
    public GameObject activeHitbox;
    public float hitBoxDamage;    
    public void CreateHitbox()
    {
        activeHitbox = Instantiate(hitboxPrefab, hitboxPoint.position, transform.rotation);
        activeHitbox.GetComponent<Hitbox>().SetDamage(hitBoxDamage);
    }

    public void DestroyHitbox()
    {
        Destroy(activeHitbox);
    } 
}  
