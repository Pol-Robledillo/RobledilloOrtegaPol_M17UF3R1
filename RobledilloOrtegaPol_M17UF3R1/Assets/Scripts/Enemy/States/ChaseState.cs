using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChaseState", menuName = "StatesSO/Chase")]

public class ChaseState : StateSO
{
    public override void OnStateEnter(EnemyBehaviour enemy)
    {
        enemy.animator.SetBool("Run", true);
    }
    public override void OnStateUpdate(EnemyBehaviour enemy)
    {
        enemy.pathfinding.Chase();
    }
    public override void OnStateExit(EnemyBehaviour enemy)
    {
        enemy.animator.SetBool("Run", false);
    }
}
