using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Idle");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            player.SwitchState(player.DodgeLeftState);
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            player.SwitchState(player.DodgeRightState);
        }
    }

}
