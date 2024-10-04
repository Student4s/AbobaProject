using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveComponent : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    public bool isEnemyTurn;
    public bool isMove;
    [SerializeField] public bool isTurnBased = false;

    [SerializeField] private PlayerCrutch top;
    [SerializeField] private PlayerCrutch bot;
    [SerializeField] private PlayerCrutch right;
    [SerializeField] private PlayerCrutch left;

    public Vector3 startPos;

    private Vector2 direction;

    void Start(){
        startPos = transform.position;
    }

    public void Restart(){
        transform.position = startPos;
    }

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
            Debug.Log("aboba");
            MoveRight();
        }
        } 
        else {
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }


    }

    public void MoveTop()
    {
        if(!top.isTouch)
        {
            if(!isEnemyTurn || !isTurnBased)
            {
                top.isActive = true;
                isMove = true;
                direction = -Vector2.down;
                Debug.Log("Move T");
            }
        }
    }
    public void MoveLeft()
    {
        if (!left.isTouch)
        {
            if (!isEnemyTurn || !isTurnBased)
            {
                left.isActive = true;
                isMove = true;
                direction = Vector2.left;
                Debug.Log("Move L");
            }
        }
    }
    public void MoveBot()
    {
        if (!bot.isTouch)
        {
            if (!isEnemyTurn || !isTurnBased)
            {
                bot.isActive = true;
                isMove = true;
                direction = Vector2.down;
                Debug.Log("Move B");
            }
        }
    }
    public void MoveRight()
    {
        if (!right.isTouch)
        {
            if (!isEnemyTurn || !isTurnBased)
            {
                right.isActive = true;
                isMove = true;
                direction = Vector2.right;
                Debug.Log("Move R");
            }
        }
    }

    public void ChangeTurn()
    {
        isEnemyTurn = false;
    }

}
