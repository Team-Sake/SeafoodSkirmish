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
        // currentTime -= 1* Time.deltaTime;
        if (Input.GetKeyDown("space"))
        {
            player.SwitchState(player.AttackStartupState);
        }
        else if (animation.isAtCenter)
        {
            player.SwitchState(player.IdleState);
        }
    }

}
