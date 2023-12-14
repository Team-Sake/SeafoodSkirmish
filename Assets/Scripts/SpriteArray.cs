using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteArray : MonoBehaviour
{
    public static SpriteArray Instance;

    public Sprite[] spriteArray;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
      
    }
    //     // DefaultPosition = enemy.transform.position;      
    //     // isStartupLeft = false;
    //     // isAttackingLeft = false;
    //     // isStartupRight = false;
    //     // isAttackingRight = false;
    //     // isRecovering = false;
    // }
}
