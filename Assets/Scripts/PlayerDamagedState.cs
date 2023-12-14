using UnityEngine;

public class PlayerDamagedState : PlayerBaseState
{
    float currentTime = 0f;
    float startingTime = 1f;

    public override void EnterState(PlayerStateManager player)
    {
        player.gameObject.GetComponent<AudioSourceManager>().PlayDamaged();
        Debug.Log("Damaged");
        currentTime = startingTime;
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite != null)
        {
        spriteRenderer.sprite = PlayerSpriteArray.Instance.playerSpriteArray[4];
        }
    }



    public override void UpdateState(PlayerStateManager player)
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            if (player.gameObject.GetComponent<HealthManager>().IsDead())
            {
                player.SwitchState(player.DeadState);
            }
            else
            {
                player.SwitchState(player.IdleState);
            }
            
        }
    }

    public override void OnTriggerEnter2D(PlayerStateManager player, Collider2D collider)
    {
        //Player is already damaged, do not overlap damage
        return;
    }
}
