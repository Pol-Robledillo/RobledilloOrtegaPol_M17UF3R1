using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackState", menuName = "StatesSO/Attack")]

public class AttackState : StateSO
{
    public override void OnStateEnter(EnemyBehaviour enemy)
    {
        enemy.StopCoroutine(Attack(enemy));
        enemy.StartCoroutine(Attack(enemy));
    }
    public override void OnStateUpdate(EnemyBehaviour enemy)
    {
    }
    public override void OnStateExit(EnemyBehaviour enemy)
    {
        enemy.StopCoroutine(Attack(enemy));
    }
    private IEnumerator Attack(EnemyBehaviour enemy)
    {
        while (enemy.InAttackRange)
        {
            if (!enemy.animator.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack"))
            {
                enemy.animator.SetTrigger("Attack");
                yield return new WaitForSeconds(0.2f);
                enemy.target.GetComponent<IDamageable>().TakeDamage(10);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
