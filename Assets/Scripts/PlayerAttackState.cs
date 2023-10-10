using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    float currentTime = 0f;
    float startingTime = 1f;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Attack");
        currentTime = startingTime;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0)
        {
            player.SwitchState(player.RecoveryState);
        }
    }
}
