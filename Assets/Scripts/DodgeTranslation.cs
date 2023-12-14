using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DodgeTranslation : MonoBehaviour
{
    public Transform player;
    public GameObject targetLeft;
    public GameObject targetRight;
    public float speed;

    public bool isLeft;
    public bool isRight;
    
    private float remainingTime;
    public float dodgeTime;

    public bool isAtCenter;

    Vector3 DefaultPosition;

    public float health;

    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        isAtCenter = true;
        isLeft = false;
        isRight = false;
        remainingTime = dodgeTime;
        DefaultPosition = player.transform.position;
    }

    void displayHP(float hp)
    {
        textMeshPro.text = string.Format("Health: {0}", hp);
    }

    void FixedUpdate()
    {
        health = player.gameObject.GetComponent<HealthManager>().currentHealth;
        displayHP(health);
        if (player.transform.position != DefaultPosition)
        {
            isAtCenter = false;
        }
        else
        {
            isAtCenter = true;
        }

        if (isLeft)
        {

            player.position = Vector3.MoveTowards(player.position, targetLeft.transform.position, speed);
            remainingTime -= Time.deltaTime;
            if (remainingTime < 0)
            {
                isLeft = false;
                remainingTime = dodgeTime;
            }
        }
        else if (isRight)
        {
            player.position = Vector3.MoveTowards(player.position, targetRight.transform.position, speed);
            remainingTime -= Time.deltaTime;
            if (remainingTime < 0)
            {
                isRight = false;
                remainingTime = dodgeTime;
            }
        }
        else
        {
            player.position = Vector3.MoveTowards(player.position, DefaultPosition, speed);
        }
    }

    


}
