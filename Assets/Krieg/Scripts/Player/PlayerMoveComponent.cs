using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveComponent : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    public bool isMove;


    [SerializeField] private PlayerCrutch top;
    [SerializeField] private PlayerCrutch bot;
    [SerializeField] private PlayerCrutch right;
    [SerializeField] private PlayerCrutch left;

    private Vector2 direction;

    private void OnEnable()
    {
        Crutch.Change += ChangeTurn;
    }
    private void OnDisable()
    {
        Crutch.Change -= ChangeTurn;
    }
    void Update()
    {
        if(isMove)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    public void MoveTop()
    {
        if(!isMove)
        {
            if (!top.isTouch)
            {
                if (!TurnChanger.isEnemyTurn)
                {
                    isMove = true;
                    direction = -Vector2.down;
                }
            }
        }
    }
    public void Moveleft()
    {
        if (!isMove)
        {
            if (!left.isTouch)
            {
                if (!TurnChanger.isEnemyTurn)
                {
                    isMove = true;
                    direction = Vector2.left;
                }
            }
        } 
    }
    public void MoveBot()
    {
        if (!isMove)
        {
            if (!bot.isTouch)
            {
                if (!TurnChanger.isEnemyTurn)
                {
                    isMove = true;
                    direction = Vector2.down;
                }
            }
        }
    }
    public void MoveRight()
    {
        if (!isMove)
        {
            if (!right.isTouch)
            {
                if (!TurnChanger.isEnemyTurn)
                {
                    isMove = true;
                    direction = Vector2.right;
                }
            }
        }
    }

    public void ChangeTurn()
    {
        TurnChanger.isEnemyTurn = false;
    }

}
