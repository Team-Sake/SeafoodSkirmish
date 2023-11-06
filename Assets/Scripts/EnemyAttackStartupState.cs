using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackStartupState : EnemyBaseState
{
    float timeRemaining;
    EnemyTranslate animation;
    public override void EnterState(EnemyStateManager enemy)
    {
        int rand = Random.Range(0,2);
        Debug.Log("Enemy Startup");
        animation = enemy.gameObject.GetComponent<EnemyTranslate>();
        timeRemaining = animation.attackStartupTime;
        if (rand == 0)
        {
            animation.isStartupLeft = true;
        }
        else
        {
            animation.isStartupRight = true;
        }
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collider)
    {
        return;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (animation.enemy.position == animation.startupLeft.transform.position || animation.enemy.position == animation.startupRight.transform.position)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                animation.isStartupLeft = false;
                animation.isStartupRight = false;
                enemy.SwitchState(enemy.attackState);
            }
        }
    }
    
}
