using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrutch : MonoBehaviour
{
    public bool isTouch;
    [SerializeField] private PlayerMoveComponent player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            player.isMove = false;
            player.isEnemyTurn = true;
            isTouch = true;
        }

        if(collision.GetComponent<Enemy>() != null)
        {
            if (player.isMove)
            {
                player.transform.position = collision.transform.position;
                collision.GetComponent<Enemy>().Die();
                player.isEnemyTurn = true;
                player.isMove = false;
            }
            else
            {
                Destroy(player.gameObject);
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
