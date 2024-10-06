using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyTargetsMark[] targets;
    private Vector3 startPos;
    private Level currentLevel;


    public void AttackPlayer()
    {
        Destroy(TurnChanger.player);
        Debug.Log("Im attack");
    }// Start is called before the first frame update
    void Start (){
        startPos = transform.position;
        currentLevel = GetComponentInParent<Level>();
    }
   public void Die()
    {
        // Destroy(gameObject);
        gameObject?.SetActive(false);
        // ? is for null check

        currentLevel.enemiesNum -= 1;
    }

    public void Restart(){
        transform.position = startPos;
        gameObject?.SetActive(true);
    }

}
