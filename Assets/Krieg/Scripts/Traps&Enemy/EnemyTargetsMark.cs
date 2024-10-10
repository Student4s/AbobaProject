using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetsMark : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private bool canAttack;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMoveComponent>() != null)
        {
            canAttack = true;
            if (SceneController.isEnemyTurn && canAttack)
            {
                Debug.Log("2");
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
