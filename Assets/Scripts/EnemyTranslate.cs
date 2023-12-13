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
    public GameObject enemyPrefab;
    public GameObject activeEnemy;
    public float speed;
    public float attackTime;
    public float recoveryTime;
    public float attackStartupTime;
    public float vulnerableTime;
    public Vector3 DefaultPosition;
    public bool isStartupLeft;
    public bool isStartupRight;
    public bool isAttackingLeft;
    public bool isAttackingRight;
    public bool isRecovering;
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(myPrefab);
        // Instantiate(myPrefab, new Vector3(0,0,0), Quaternion.identity);
        if (DifficultyLevel.difficulty == 1){
            speed = 2;
            attackStartupTime = 0.5f;
            //enemy prefab is set to speed 1
            // activeEnemy = Instantiate(enemyPrefab, enemy.transform.position, Quaternion.identity);
            Debug.Log("Enemy 1");
           
        }
        else if (DifficultyLevel.difficulty == 2){
            //enemy prefav set to speed 2
            speed = 4;
            attackStartupTime = 0.4f;
            // Instantiate(enemyPrefab, enemy.transform.position, Quaternion.identity);
            // Debug.Log("Enemy 2");
           
        }
        else if (DifficultyLevel.difficulty == 3){
            speed = 6;
            attackStartupTime = 0.3f;
            //enemy prefav is set to speed 3
            // Instantiate(enemyPrefab, enemy.transform.position, Quaternion.identity);
            // Debug.Log("Enemy 3");
        }
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

    public Transform getEnemy()
    {
        return enemy;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
