using UnityEngine;

public class PlayerDodgeLeftState : PlayerBaseState
{
    float currentTime = 0f;
    float startingTime = 1f;
    DodgeTranslation animation;
    
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Dodge Left");
        currentTime = startingTime;
        // Awake();
        // animation.StartCoroutine(animation.dodgeLeft());
    }

    private void Awake()
    {
        GameObject gameObject = new GameObject("DodgeTranslation");
        animation = gameObject.AddComponent<DodgeTranslation>();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        currentTime -= 1 * Time.deltaTime;
        if (Input.GetKeyDown("space"))
        {
            player.SwitchState(player.AttackStartupState);
        }
        else if (currentTime <= 0)
        {
            player.SwitchState(player.IdleState);
        }
    }

}
