using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRecoveryState : EnemyBaseState
{
    float timeLeft;
    EnemyTranslate animation;
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy Recovery State");
        animation = enemy.gameObject.GetComponent<EnemyTranslate>();
        animation.isRecovering = true;
        timeLeft = animation.recoveryTime;
        
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (animation.enemy.position == animation.DefaultPosition)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                animation.isRecovering = false;
                enemy.SwitchState(enemy.idleState);
            }
        }
    }
}
