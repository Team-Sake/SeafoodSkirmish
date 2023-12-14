using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteArray : MonoBehaviour
{
    public static PlayerSpriteArray Instance;

    public Sprite[] playerSpriteArray;

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
}
