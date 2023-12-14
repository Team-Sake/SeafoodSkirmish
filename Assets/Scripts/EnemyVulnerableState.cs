using UnityEngine;

public class EnemyVulnerableState : EnemyBaseState
{
    AudioSource audioSource;

    float timeLeft;
    SpriteRenderer renderer;
    public override void EnterState(EnemyStateManager enemy)
    {
        renderer = enemy.GetComponent<SpriteRenderer>();
        // renderer.color = Color.yellow;
        timeLeft = enemy.GetComponent<EnemyTranslate>().vulnerableTime;
        Debug.Log("Enemy Vulnerable");
        // if (DifficultyLevel.difficulty == 1){
        //     if (renderer.sprite != null)
        //     {
        //     renderer.sprite = SpriteArray.Instance.spriteArray[13];
        //     }
        // }
        // else if (DifficultyLevel.difficulty == 2){
        //     if (renderer.sprite != null)
        //     {
        //     renderer.sprite = SpriteArray.Instance.spriteArray[14];
        //     }
        // }
        // else if (DifficultyLevel.difficulty == 3){
        //     if (renderer.sprite != null)
        //     {
        //     renderer.sprite = SpriteArray.Instance.spriteArray[15];
        //     }
        // }
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collider)
    {
        SpriteRenderer renderer = enemy.GetComponent<SpriteRenderer>();
        if (collider.gameObject.CompareTag("Player Hitbox"))
        {
            audioSource = enemy.gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            Debug.Log("Enemy Damaged");
            enemy.GetComponent<HealthManager>().TakeDamage(collider.GetComponent<Hitbox>().damage);
            if (DifficultyLevel.difficulty == 1){
                if (renderer.sprite != null)
                {
                    renderer.sprite = SpriteArray.Instance.spriteArray[13];

                    
                }
            }
            else if (DifficultyLevel.difficulty == 2){
                if (renderer.sprite != null)
                {
                    renderer.sprite = SpriteArray.Instance.spriteArray[14];
                }
            }
            else if (DifficultyLevel.difficulty == 3){
                if (renderer.sprite != null)
                {
                    renderer.sprite = SpriteArray.Instance.spriteArray[15];
                }
            }
            // if (renderer.sprite != null)
            // {
            //     // spriteRenderer.sprite = spriteArray[1];
            //     renderer.sprite = SpriteArray.Instance.spriteArray[4];
            // }
            if (enemy.GetComponent<HealthManager>().IsDead())
            {
                renderer.color = Color.gray;
                enemy.SwitchState(enemy.deadState);
            }
        }   
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            renderer.color = Color.white;
            enemy.SwitchState(enemy.recoveryState);
        }
    }
}
