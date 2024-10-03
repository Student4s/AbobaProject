using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyTargetsMark[] targets;


    public void Die()
    {
        Destroy(gameObject);
    }

    public void AttackPlayer()
    {
        Debug.Log("Im attack");
    }
}
