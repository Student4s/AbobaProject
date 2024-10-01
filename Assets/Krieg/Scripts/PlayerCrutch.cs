using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrutch : MonoBehaviour
{
    public bool isTouch;
    [SerializeField] private PlayerMoveComponent player;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            player.isMove = false;
            player.isEnemyTurn = true;
            isTouch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            //idk what to do
        }
    }
}
