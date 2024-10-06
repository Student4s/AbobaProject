using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveComponent : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] public bool isTurnBased = false;
    public bool isMove;

    
    [SerializeField] private PlayerCrutch top;
    [SerializeField] private PlayerCrutch bot;
    [SerializeField] private PlayerCrutch right;
    [SerializeField] private PlayerCrutch left;

    private Vector2 direction;
    public Vector3 startPos;

    private void OnEnable()
    {
        Crutch.Change += ChangeTurn;
    }
    private void OnDisable()
    {
        Crutch.Change -= ChangeTurn;
    }

    public void Restart(){
        transform.position = startPos;
    }

    void Start(){
        startPos = transform.position;
    }

    void Update()
    {
        if(!isMove){
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveTop();
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveBot();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            MoveRight();
        }
        } else {
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    public void MoveTop()
    {
        if(!isMove)
        {
            if (!top.isTouch)
            {
                if (!TurnChanger.isEnemyTurn || !isTurnBased)
                {
                    top.isActive = true;
                    isMove = true;
                    direction = -Vector2.down;
                }
            }
        }
    }
    public void MoveLeft()
    {
        if (!isMove)
        {
            if (!left.isTouch)
            {
                if (!TurnChanger.isEnemyTurn || !isTurnBased)
                {
                    left.isActive = true;
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
                if (!TurnChanger.isEnemyTurn || !isTurnBased)
                {
                    bot.isActive = true;
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
                if (!TurnChanger.isEnemyTurn || !isTurnBased)
                {
                    right.isActive = true;
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
