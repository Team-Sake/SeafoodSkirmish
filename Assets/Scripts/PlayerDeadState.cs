using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Dead");
    }

    public override void OnTriggerEnter2D(PlayerStateManager player, Collider2D collider)
    {
        return;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        return;
    }
}
