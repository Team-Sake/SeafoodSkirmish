using UnityEngine;

public class EnemyVulnerableState : EnemyBaseState
{
    AudioSource audioSource;

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
            audioSource = enemy.gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            Debug.Log("Enemy Damaged");
            enemy.GetComponent<HealthManager>().TakeDamage(collider.GetComponent<Hitbox>().damage);
            if (enemy.GetComponent<HealthManager>().IsDead())
            {
                renderer.color = Color.gray;
                enemy.SwitchState(enemy.deadState);
            }
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
