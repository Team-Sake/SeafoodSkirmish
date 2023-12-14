using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Dead");
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite != null)
        {
            // spriteRenderer.sprite = spriteArray[1];
            spriteRenderer.sprite = PlayerSpriteArray.Instance.playerSpriteArray[2];
        }
        else {
            Debug.LogWarning("SpriteRenderer is missing.");
        }
    }

    public override void OnTriggerEnter2D(PlayerStateManager player, Collider2D collider)
    {
        return;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        return;
    }
}
