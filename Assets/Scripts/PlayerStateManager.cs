using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerBaseState currentState;
    public PlayerIdleState IdleState = new  PlayerIdleState();
    public PlayerDodgeLeftState DodgeLeftState = new PlayerDodgeLeftState();
    public PlayerDodgeRightState DodgeRightState = new PlayerDodgeRightState();
    public PlayerAttackStartupState AttackStartupState = new PlayerAttackStartupState();
    public PlayerAttackState AttackState = new PlayerAttackState();
    public PlayerRecoveryState RecoveryState = new PlayerRecoveryState();
    void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
