using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    PlayerBaseState currentState;
    public PlayerIdleState IdleState = new  PlayerIdleState();
    public PlayerDodgeLeftState DodgeLeftState = new PlayerDodgeLeftState();
    public PlayerDodgeRightState DodgeRightState = new PlayerDodgeRightState();
    public PlayerAttackStartupState AttackStartupState = new PlayerAttackStartupState();
    public PlayerAttackState AttackState = new PlayerAttackState();
    public PlayerRecoveryState RecoveryState = new PlayerRecoveryState();
    public PlayerDamagedState DamagedState = new PlayerDamagedState();
    public PlayerDeadState DeadState = new PlayerDeadState();
    void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        currentState.OnTriggerEnter2D(this, collider);
    }
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
