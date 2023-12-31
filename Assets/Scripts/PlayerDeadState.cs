using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    GameObject enemy;
    GameObject tryAgainButton;
    public override void EnterState(PlayerStateManager player)
    {
        enemy = GameObject.Find("Enemy");
        enemy.SetActive(false);
        GameObject canvas = GameObject.Find("Canvas");
        tryAgainButton = canvas.transform.Find("TryAgain").gameObject;
        tryAgainButton.SetActive(true);
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
