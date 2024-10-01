using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pawn : Enemy
{

    [SerializeField] private Transform target;

    [SerializeField] private float moveSpeed = 1f;
    private Vector2 targetPosition;// куда движется пешка

    [SerializeField] bool isEnemyTurn=false;
    [SerializeField] bool isCanDamaged=false;//чтобы можно было забирать фигуру только в ход игрока

    private void Start()
    {
        targetPosition = transform.position;
    }
    void FixedUpdate()
    {
        if(isEnemyTurn)
        {
            Vector2 playerPosition = new Vector2(Mathf.Round(target.position.x), Mathf.Round(target.position.y));

            // Определяем направление движения по оси X
            if (Mathf.Abs(playerPosition.x - transform.position.x) > Mathf.Abs(playerPosition.y - transform.position.y))
            {
                if (playerPosition.x > transform.position.x)
                    targetPosition = new Vector2(transform.position.x + 1, transform.position.y); // Движение вправо
                else
                    targetPosition = new Vector2(transform.position.x - 1, transform.position.y); // Движение влево
            }
            // Определяем направление движения по оси Y
            else
            {
                if (playerPosition.y > transform.position.y)
                    targetPosition = new Vector2(transform.position.x, transform.position.y + 1); // Движение вверх
                else
                    targetPosition = new Vector2(transform.position.x, transform.position.y - 1); // Движение вниз
            }
        }
        if (Vector2.Distance(transform.position, targetPosition) > 0.01f)
        {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
        isEnemyTurn=false;
        isCanDamaged = false;
        }
        else
        {
        isCanDamaged = true;
        }
    }


    public void ChangeTurn()
    {
        isEnemyTurn = !isEnemyTurn;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Player")
        {
            if( !isCanDamaged)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
}
