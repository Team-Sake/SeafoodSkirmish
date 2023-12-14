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
        SpriteRenderer spriteRenderer = animation.GetComponent<SpriteRenderer>();

        if (spriteRenderer.sprite != null)
        {
            // spriteRenderer.sprite = spriteArray[1];
            spriteRenderer.sprite = PlayerSpriteArray.Instance.playerSpriteArray[1];
            spriteRenderer.flipX = true;
        }
        else {
            Debug.LogWarning("SpriteRenderer is missing.");
        }
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
