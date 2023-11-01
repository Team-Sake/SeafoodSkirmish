using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTranslate : MonoBehaviour
{
    public Transform enemy;
    public GameObject startupLeft;
    public GameObject startupRight;
    public GameObject targetLeft;
    public GameObject targetRight;
    public float speed;
    public float attackStartupTime;
    Vector3 DefaultPosition;
    public bool isStartupLeft;
    public bool isStartupRight;
    public bool isAttackingLeft;
    public bool isAttackingRight;
    public bool isRecovering;
    // Start is called before the first frame update
    void Start()
    {
        DefaultPosition = enemy.transform.position;      
        isStartupLeft = false;
        isAttackingLeft = false;
        isStartupRight = false;
        isAttackingRight = false;
        isRecovering = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStartupLeft)
        {
            enemy.position = Vector3.MoveTowards(enemy.position, startupLeft.transform.position, speed);
        }
        else if (isStartupRight)
        {
            enemy.position = Vector3.MoveTowards(enemy.position, startupRight.transform.position, speed);
        }
        else if (isAttackingLeft)
        {
            enemy.position = Vector3.MoveTowards(enemy.position, targetLeft.transform.position, speed);
        }
        else if (isAttackingRight)
        {
            enemy.position = Vector3.MoveTowards(enemy.position, targetRight.transform.position, speed);
        }
        else if (isRecovering)
        {
            enemy.position = Vector3.MoveTowards(enemy.position, DefaultPosition, speed);
        }
    }
}
