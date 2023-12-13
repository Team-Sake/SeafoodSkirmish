using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwapper : MonoBehaviour
{
    public Sprite newSprite;
    // Start is called before the first frame update
    public void SwapSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && newSprite != null)
        {
            //change the sprite to the new sprite
            spriteRenderer.sprite = newSprite;
        }
        else{
            Debug.Log("SpriteRenderer is missing.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
