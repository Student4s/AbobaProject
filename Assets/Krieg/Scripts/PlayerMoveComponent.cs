using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveComponent : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    public bool isEnemyTurn;
    public bool isMove;


    [SerializeField] private PlayerCrutch top;
    [SerializeField] private PlayerCrutch bot;
    [SerializeField] private PlayerCrutch right;
    [SerializeField] private PlayerCrutch left;

    private Vector2 direction;

    void Update()
    {
        if(isMove)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    public void MoveTop()
    {
        if(!top.isTouch)
        {
            if(!isEnemyTurn)
            {
                isMove = true;
                direction = -Vector2.down;
            }
        }
    }
    public void Moveleft()
    {
        if (!left.isTouch)
        {
            if (!isEnemyTurn)
            {
                isMove = true;
                direction = Vector2.left;
            }
        }
    }


}
