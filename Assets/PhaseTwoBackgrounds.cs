using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseTwoBackgrounds : MonoBehaviour
{
    public Sprite lvl2;
    public Sprite lvl3;

    void Start()
    {
        if(DifficultyLevel.difficulty == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = lvl2;
        }
        else if(DifficultyLevel.difficulty == 3)
        {
            this.gameObject.GetComponent <SpriteRenderer>().sprite = lvl3; 
        }
    }
}
