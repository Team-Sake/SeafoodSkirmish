using UnityEngine;

public class EnemyVulnerableState : EnemyBaseState
{

    float timeLeft;
    SpriteRenderer renderer;
    public override void EnterState(EnemyStateManager enemy)
    {
        renderer = enemy.GetComponent<SpriteRenderer>();
        renderer.color = Color.yellow;
        timeLeft = enemy.GetComponent<EnemyTranslate>().vulnerableTime;
        Debug.Log("Enemy Vulnerable");
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player Hitbox"))
        {
            Debug.Log("Enemy Damaged");
        }   
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            renderer.color = Color.white;
            enemy.SwitchState(enemy.recoveryState);
        }
    }
}
