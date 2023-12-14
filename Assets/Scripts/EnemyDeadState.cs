using UnityEngine;
using TMPro;


public class EnemyDeadState : EnemyBaseState
{
    GameObject panel;
    Phase2TransitionAnimation phase2anim;
    TextMeshProUGUI fishDeadText; 
    GameObject nextLevelButton;
   
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy dead");
        GameObject canvas = GameObject.Find("Canvas");
        phase2anim = canvas.GetComponent<Phase2TransitionAnimation>();
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
