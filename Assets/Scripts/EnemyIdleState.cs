using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    int timer;
    float timeLeft;
    public float enemy_health;
    EnemyTranslate animation;

    // Start is called before the first frame update
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy_health = enemy.GetComponent<HealthManager>().currentHealth;
        Debug.Log("Enemy Idle");
        timer = Random.Range(1,3);
        timeLeft = (float)timer;
        animation = enemy.gameObject.GetComponent<EnemyTranslate>();
        SpriteRenderer spriteRenderer = animation.GetComponent<SpriteRenderer>();

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
                    spriteRenderer.sprite = SpriteArray.Instance.spriteArray[6];
                }
                else {
                    spriteRenderer.sprite = SpriteArray.Instance.spriteArray[12];
                }
            }
        }

    
        else {
            Debug.LogWarning("SpriteRenderer is missing.");
        }
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collider)
    {
        return;
    }

    // Update is called once per frame
    public override void UpdateState(EnemyStateManager enemy)
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {

            enemy.SwitchState(enemy.attackStartupState);   
        }
    }
}
