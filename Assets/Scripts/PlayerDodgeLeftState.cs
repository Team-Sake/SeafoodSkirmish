using UnityEngine;

public class PlayerDodgeLeftState : PlayerBaseState
{
    // float currentTime;
    DodgeTranslation animation;    
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Dodge Left");
        animation = player.gameObject.GetComponent<DodgeTranslation>();
        // currentTime  = animation.dodgeTime;
        animation.isLeft = true;
    }


    public override void UpdateState(PlayerStateManager player)
    {
        if (animation.isAtCenter)
        {
            player.SwitchState(player.IdleState);
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
