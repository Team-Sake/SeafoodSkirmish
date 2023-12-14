using UnityEngine;
using TMPro;


public class EnemyDeadState : EnemyBaseState
{
    GameObject panel;
    Phase2TransitionAnimation phase2anim;
    TextMeshProUGUI fishDeadText; 
    GameObject nextLevelButton;
    SpriteRenderer spriteRenderer;
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy dead");
        GameObject canvas = GameObject.Find("Canvas");
        phase2anim = canvas.GetComponent<Phase2TransitionAnimation>();
        spriteRenderer = enemy.gameObject.GetComponent<SpriteRenderer>();

        if (DifficultyLevel.difficulty == 1){
            if (spriteRenderer.sprite != null)
            {
            // spriteRenderer.sprite = spriteArray[1];
            spriteRenderer.sprite = SpriteArray.Instance.spriteArray[4];
            }
        }
        else if (DifficultyLevel.difficulty == 2){
            if (spriteRenderer.sprite != null)
            {
            // spriteRenderer.sprite = spriteArray[1];
            spriteRenderer.sprite = SpriteArray.Instance.spriteArray[16];
            }
        }
        else if (DifficultyLevel.difficulty == 3){
            if (spriteRenderer.sprite != null)
            {
            // spriteRenderer.sprite = spriteArray[1];
            spriteRenderer.sprite = SpriteArray.Instance.spriteArray[17];
            }
        }
        
        
        fishDeadText = GameObject.Find("FishDeadText").GetComponent<TextMeshProUGUI>();
        nextLevelButton = canvas.transform.Find("NextLevel").gameObject;
        fishDeadText.color = new Color(0f, 0f, 0f, 255f);
        nextLevelButton.SetActive(true);
        //phase2anim.AnimateOut();
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collider)
    {
        return;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        return;
    }
}
