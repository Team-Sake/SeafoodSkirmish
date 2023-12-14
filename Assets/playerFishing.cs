using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFishing : MonoBehaviour
{
    public Sprite playerReel;
    public Sprite playerIdle;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerReel;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerIdle;
        }
    }
}
