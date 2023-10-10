using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackStartupState : PlayerBaseState
{
    float currentTime = 0f;
    float startingTime = 1f;
    // Start is called before the first frame update
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Attack Startup");
        currentTime = startingTime;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0)
        {
            player.SwitchState(player.AttackState);
        }
    }
}
