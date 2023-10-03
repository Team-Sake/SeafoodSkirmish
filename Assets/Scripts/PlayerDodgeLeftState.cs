using UnityEngine;

public class PlayerDodgeLeftState : PlayerBaseState
{
    float currentTime = 0f;
    float startingTime = 2f;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Dodge Left");
        currentTime = startingTime;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        Debug.Log(currentTime);
        currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0)
        {
            player.SwitchState(player.IdleState);
        }
    }

}
