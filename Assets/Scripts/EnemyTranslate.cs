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
    public SpriteRenderer spriteRenderer;
    public float enemy_health;
    // public Sprite[] spriteArray;
    // Start is called before the first frame update
    void Start()
    {
        if (DifficultyLevel.difficulty == 1){
            speed = 1.2f;
            attackStartupTime = 0.5f;
            vulnerableTime = 0.75f;
            recoveryTime = 1.5f;
            //enemy prefab is set to speed 1
            // activeEnemy = Instantiate(enemyPrefab, enemy.transform.position, Quaternion.identity);
            Debug.Log("Enemy 1");
           
        }
        else if (DifficultyLevel.difficulty == 2){
            //enemy prefav set to speed 2
            speed = 1.6f;
            attackStartupTime = 0.4f;
            vulnerableTime = 0.5f;
            recoveryTime = 1.5f;
            // Instantiate(enemyPrefab, enemy.transform.position, Quaternion.identity);
            // Debug.Log("Enemy 2");
           
        }
        else if (DifficultyLevel.difficulty == 3){
            speed = 2.2f;
            attackStartupTime = 0.3f;
            vulnerableTime = 0.55f;
            recoveryTime = 1.5f;
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

            if (DifficultyLevel.difficulty == 1){
                if (spriteRenderer.sprite != null)
                {
                // spriteRenderer.sprite = spriteArray[2];
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[2];
                
                }
            }
            else if (DifficultyLevel.difficulty == 2){
                if (spriteRenderer.sprite != null)
                {
                // spriteRenderer.sprite = spriteArray[2];
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[7];
                spriteRenderer.flipX = false;
                }

            }
            else if (DifficultyLevel.difficulty == 3){
                if (spriteRenderer.sprite != null)
                {
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[10];
                spriteRenderer.flipX = false;
                }
            }
        }
        else if (isStartupRight)
        {
            enemy.position = Vector3.MoveTowards(enemy.position, startupRight.transform.position, speed);

            if (DifficultyLevel.difficulty == 1){
                if (spriteRenderer.sprite != null)
                {
                // spriteRenderer.sprite = spriteArray[2];
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[2];
                }
            }
            else if (DifficultyLevel.difficulty == 2){
                if (spriteRenderer.sprite != null)
                {
                // spriteRenderer.sprite = spriteArray[2];
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[7];
                spriteRenderer.flipX = true;
                }

            }
            else if (DifficultyLevel.difficulty == 3){
                if (spriteRenderer.sprite != null)
                {
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[10];
                spriteRenderer.flipX = true;
                }
            }
        }
        else if (isAttackingLeft)
        {
            enemy.position = Vector3.MoveTowards(enemy.position, targetLeft.transform.position, speed);

            if (DifficultyLevel.difficulty == 1){
                if (spriteRenderer.sprite != null)
                {
                // spriteRenderer.sprite = spriteArray[1];
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[1];
                }
            }
            else if (DifficultyLevel.difficulty == 2){
                if (spriteRenderer.sprite != null)
                {
                // spriteRenderer.sprite = spriteArray[1];
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[8];
                }
            }
            else if (DifficultyLevel.difficulty == 3){
                if (spriteRenderer.sprite != null)
                {
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[11];
                spriteRenderer.flipX = false;
                }
            }
        }
        else if (isAttackingRight)
        {
            enemy.position = Vector3.MoveTowards(enemy.position, targetRight.transform.position, speed);
            
            if (DifficultyLevel.difficulty == 1){
                if (spriteRenderer.sprite != null)
                {
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[1];
                }
            }
            else if (DifficultyLevel.difficulty == 2){
                if (spriteRenderer.sprite != null)
                {
                // spriteRenderer.sprite = spriteArray[1];
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[8];
                }
            }
            else if (DifficultyLevel.difficulty == 3){
                if (spriteRenderer.sprite != null)
                {
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[11];
                spriteRenderer.flipX = true;
                }
            }
        }
        else if (isRecovering)
        {
            enemy.position = Vector3.MoveTowards(enemy.position, DefaultPosition, speed);

            enemy_health = enemy.GetComponent<HealthManager>().currentHealth;
            
            if (DifficultyLevel.difficulty == 1){
                if (spriteRenderer.sprite != null)
                {
                    if (enemy_health < 30){
                        spriteRenderer.sprite = SpriteArray.Instance.spriteArray[3];
                    }
                    else {
                        spriteRenderer.sprite = SpriteArray.Instance.spriteArray[0];
                    }
                }
            }
            else if (DifficultyLevel.difficulty == 2){
                if (spriteRenderer.sprite != null)
                {
                    if (enemy_health < 30){
                        spriteRenderer.sprite = SpriteArray.Instance.spriteArray[9];
                    }
                    else {
                        spriteRenderer.sprite = SpriteArray.Instance.spriteArray[5];
                    }
                }
            }
            else if (DifficultyLevel.difficulty == 3){
                if (spriteRenderer.sprite != null)
                {
                    if (enemy_health < 30){
                        spriteRenderer.sprite = SpriteArray.Instance.spriteArray[12];
                    }
                    else {
                        spriteRenderer.sprite = SpriteArray.Instance.spriteArray[6];
                    }
                }
            }
        }

    }

    public Transform getEnemy()
    {
        return enemy;
    }
}
