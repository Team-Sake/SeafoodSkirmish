using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Idle");
        SpriteRenderer spriteRenderer = player.gameObject.GetComponent<SpriteRenderer>();

        if (spriteRenderer.sprite != null)
        {
            // spriteRenderer.sprite = spriteArray[1];
            spriteRenderer.sprite = PlayerSpriteArray.Instance.playerSpriteArray[0];
        }
        else {
            Debug.LogWarning("SpriteRenderer is missing.");
        }

    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetKeyDown("space"))
        {
            player.SwitchState(player.AttackStartupState);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            player.SwitchState(player.DodgeLeftState);
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            player.SwitchState(player.DodgeRightState);
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
