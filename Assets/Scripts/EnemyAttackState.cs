using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    float timeLeft;
    EnemyTranslate animation;
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy Attack");
        animation = enemy.gameObject.GetComponent<EnemyTranslate>();
        timeLeft = animation.attackTime;
        if (animation.getEnemy().position == animation.startupLeft.transform.position)
        {
            animation.isAttackingLeft = true;
            enemy.GetComponent<EnemyAttackManager>().CreateHitboxLeft();
        }
        else
        {
            animation.isAttackingRight = true;
            enemy.GetComponent<EnemyAttackManager>().CreateHitboxRight();
        }
        
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collider)
    {
        return;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (animation.getEnemy().position == animation.targetLeft.transform.position || animation.getEnemy().position == animation.targetRight.transform.position)
        {
            timeLeft -= Time.deltaTime;
        
        
            if (timeLeft <= 0)
            {
                
                animation.isAttackingLeft = false;
                animation.isAttackingRight = false;
                enemy.GetComponent<EnemyAttackManager>().DestroyHitbox();
                enemy.SwitchState(enemy.vulnerableState);
            }
        }
    }
    // public Transform enemy;
    // [SerializeField] Transform[] AttackPositions;
    // [SerializeField] float EnemySpeed;

    // int NextAttackPosIndex;
    // Transform NextAttackPos;
    // Vector3 DefaultPosition;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     // NextAttackPos = AttackPositions[0];
    //     NextAttackPos = AttackPositions[Random.Range(1, AttackPositions.Length)];
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     MoveEnemy();
    //     // enemy.position = Vector3.MoveTowards(transform.position, NextAttackPos.position, EnemySpeed * Time.deltaTime);
    //     StartCoroutine(ResetEnemy());
    // }

    // void MoveEnemy()
    // {

    //     if (enemy.position == NextAttackPos.position)
    //     {
    //         // NextAttackPosIndex++;
    //         // if (NextAttackPosIndex >= AttackPositions.Length)
    //         // {
    //         //     NextAttackPosIndex = 0;
    //         // }
    //         // NextAttackPos = AttackPositions[1];
    //         // NextAttackPos = AttackPositions[Random.Range(1, AttackPositions.Length)];
    //         // Debug.Log(NextAttackPos);

    //     }
    //     else
    //     {
    //         enemy.position = Vector3.MoveTowards(enemy.position, NextAttackPos.position, EnemySpeed * Time.deltaTime);
    //         // NextAttackPos = AttackPositions[0];
    //         // enemy.position = Vector3.MoveTowards(enemy.position, NextAttackPos.position, EnemySpeed * Time.deltaTime);

    //         // transform.position = Vector3.MoveTowards(enemy.position, DefaultPosition, EnemySpeed * Time.deltaTime);

    //     }

    // }

    // public IEnumerator ResetEnemy()
    //     {
    //         yield return new WaitForSeconds(3);
    //         NextAttackPos = AttackPositions[0];
    //         // Debug.Log(NextAttackPos);
    //         // enemy.position = Vector3.MoveTowards(transform.position, NextAttackPos.position, EnemySpeed * Time.deltaTime);
    //         enemy.position = Vector3.MoveTowards(enemy.position, NextAttackPos.position, EnemySpeed * Time.deltaTime);

    //     }
}
