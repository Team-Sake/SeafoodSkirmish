using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    // Start is called before the first frame update

    EnemyBaseState currentState;    
    public EnemyIdleState idleState =  new EnemyIdleState();
    public EnemyAttackStartupState attackStartupState = new EnemyAttackStartupState();
    public EnemyAttackState attackState = new EnemyAttackState();
    public EnemyRecoveryState recoveryState = new EnemyRecoveryState();
    public EnemyVulnerableState vulnerableState = new EnemyVulnerableState();
    public EnemyDeadState deadState = new EnemyDeadState();
    // public EnemyStunnedState stunnedState = new EnemyStunnedState(); 
    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        currentState.OnTriggerEnter2D(this, collider);
    }
    void Update()
    {
        currentState.UpdateState(this);
        
    }

    public void SwitchState(EnemyBaseState state){
        currentState = state;
        currentState.EnterState(this);

    }
}
