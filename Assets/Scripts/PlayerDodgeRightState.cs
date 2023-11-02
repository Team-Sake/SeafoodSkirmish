using UnityEngine;

public class PlayerDodgeRightState : PlayerBaseState
{
    // float currentTime;
    DodgeTranslation animation;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Dodge Right");
        animation = player.gameObject.GetComponent<DodgeTranslation>();
        // currentTime  = animation.dodgeTime;
        animation.isRight = true;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        // currentTime -= 1 * Time.deltaTime;
        if (Input.GetKeyDown("space"))
        {
            player.SwitchState(player.AttackStartupState);
        }
        else if (animation.isAtCenter)
        {
            player.SwitchState(player.IdleState);
        }
    }
    public override void OnTriggerEnter2D(PlayerStateManager player, Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy Hitbox"))
        {
            player.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(collider.gameObject.GetComponent<Hitbox>().GetDamage());
            player.SwitchState(player.DamagedState);
        }
    }

}
