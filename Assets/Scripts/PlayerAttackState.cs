using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    float currentTime = 0f;
    float startingTime = 0.2f;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Attack");
        currentTime = startingTime;
        player.gameObject.GetComponent<PlayerAttackManager>().CreateHitbox();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            player.gameObject.GetComponent<PlayerAttackManager>().DestroyHitbox();
            player.SwitchState(player.RecoveryState);
        }
    }

    public override void OnTriggerEnter2D(PlayerStateManager player, Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy Hitbox"))
        {
            player.gameObject.GetComponent<PlayerAttackManager>().DestroyHitbox();
            player.gameObject.GetComponent<HealthManager>().TakeDamage(collider.gameObject.GetComponent<Hitbox>().GetDamage());
            player.SwitchState(player.DamagedState);
        }
    }
}
