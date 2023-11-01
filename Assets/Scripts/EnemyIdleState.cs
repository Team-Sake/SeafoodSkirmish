using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    int timer;
    float timeLeft;
    // Start is called before the first frame update
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy Idle");
        timer = Random.Range(1,3);
        timeLeft = (float)timer;
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
