using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetsMark : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private bool canAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMoveComponent>() != null)
        {
            canAttack = true;
            if (TurnChanger.isEnemyTurn && canAttack)
            {
                enemy.AttackPlayer();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMoveComponent>() != null)
        {
            canAttack = false;
        }
    }
}
