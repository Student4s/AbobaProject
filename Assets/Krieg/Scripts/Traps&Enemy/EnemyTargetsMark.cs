using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetsMark : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private bool canAttack;
    public bool isTriggered ;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMoveComponent>() != null)
        {
            canAttack = true;
            if (SceneController.isEnemyTurn && canAttack)
            {
                isTriggered = true;
                enemy.AnimationAttack();
                // Debug.Log("2");
                enemy.AttackPlayer();
            }
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMoveComponent>() != null)
        {
            isTriggered = false;
            canAttack = false;
        }
    }
}
