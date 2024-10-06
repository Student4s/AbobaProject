using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrutch : MonoBehaviour// what player touch
{
    public bool isActive;
    public bool isTouch;
    [SerializeField] private PlayerMoveComponent player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isActive){
        if(collision.CompareTag("Wall"))
        {
            player.isMove = false;
            isActive = false;
            TurnChanger.isEnemyTurn = true;
            isTouch = true;
        }
        if(collision.GetComponent<Enemy>() != null)
        {
            if (player.isMove)
            {
                player.transform.position = collision.transform.position;
                collision.GetComponent<Enemy>().Die();
                TurnChanger.isEnemyTurn = true;
                player.isMove = false;
                isActive = false;
            }
            else
            {
                Destroy(player.gameObject);
            }
        }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            isTouch = false;
        }
    }
}
