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
    // public Sprite[] spriteArray;
    // Start is called before the first frame update
    void Start()
    {
        if (DifficultyLevel.difficulty == 1){
            speed = 1f;
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
            recoveryTime = 1.3f;
            // Instantiate(enemyPrefab, enemy.transform.position, Quaternion.identity);
            // Debug.Log("Enemy 2");
           
        }
        else if (DifficultyLevel.difficulty == 3){
            speed = 2.3f;
            attackStartupTime = 0.3f;
            vulnerableTime = 0.4f;
            recoveryTime = 1.0f;
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

            if (DifficultyLevel.difficulty == 1){
                if (spriteRenderer.sprite != null)
                {
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[0];
                }
            }
            else if (DifficultyLevel.difficulty == 2){
                if (spriteRenderer.sprite != null)
                {
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[9];
                }
            }
            else if (DifficultyLevel.difficulty == 3){
                if (spriteRenderer.sprite != null)
                {
                spriteRenderer.sprite = SpriteArray.Instance.spriteArray[12];
                }
            }

        }
    }

    public Transform getEnemy()
    {
        return enemy;
    }
}
