using UnityEngine;

public class PlayerDodgeRightState : PlayerBaseState
{
    float currentTime = 0f;
    float startingTime = 1f;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Dodge Right");
        currentTime = startingTime;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0)
        {
            player.SwitchState(player.IdleState);
        }
    }

}
