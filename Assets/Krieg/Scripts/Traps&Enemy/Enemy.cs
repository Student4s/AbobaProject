using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyTargetsMark[] targets;
    private Vector3 startPos;
    private Level currentLevel;
    private SceneController sctrl;
    private PlayerMoveComponent playerMove;

    public void Start()
    {
        startPos = transform.position;
        currentLevel = GetComponentInParent<Level>();
        GameObject targetObj = GameObject.Find("SceneController");
        sctrl = targetObj.GetComponent<SceneController>();
        targetObj = GameObject.Find("Player");
            playerMove = targetObj.GetComponent<PlayerMoveComponent>();
    }

    public void AttackPlayer()
    {
        // StartCoroutine(SceneController.FreezeGame());

        //        Destroy(TurnChanger.player);
        playerMove.AnimationDeath();
        sctrl.PlayEnemyAttack();
        //SceneController.player.SetActive(false);
        // Debug.Log("Im attack");
    }// Start is called before the first frame update
    public void Die()
    {
        // Destroy(gameObject);
        gameObject?.SetActive(false);
        // ? is for null check

        currentLevel.enemiesNum -= 1;
    }

    public void Restart()
    {
        transform.position = startPos;
        gameObject?.SetActive(true);
    }

}
