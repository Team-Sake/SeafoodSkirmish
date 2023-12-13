using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    GameObject panel;
    Phase2TransitionAnimation phase2anim;
 
    
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy dead");
        GameObject canvas = GameObject.Find("Canvas");
        phase2anim = canvas.GetComponent<Phase2TransitionAnimation>();
        phase2anim.AnimateOut();
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collider)
    {
        return;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        return;
    }
}
