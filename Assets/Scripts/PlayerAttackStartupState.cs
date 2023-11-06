using UnityEngine;

public class PlayerAttackStartupState : PlayerBaseState
{
    float currentTime = 0f;
    float startingTime = 0.2f;
    // Start is called before the first frame update
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Attack Startup");
        currentTime = startingTime;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            player.SwitchState(player.AttackState);
        }
    }

    public override void OnTriggerEnter2D(PlayerStateManager player, Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy Hitbox"))
        {
            player.gameObject.GetComponent<HealthManager>().TakeDamage(collider.gameObject.GetComponent<Hitbox>().GetDamage());
            player.SwitchState(player.DamagedState);
        }
    }
}
