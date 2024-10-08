using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrutch : MonoBehaviour// what player touch
{
    public bool isActive = false;
    public bool isTouch = false;
    [SerializeField] private PlayerMoveComponent player;

    void Start(){
        isActive = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isActive){
        if(collision.CompareTag("Wall"))
        {
            SceneController.isEnemyTurn = true;
            player.isMove = false;
            isActive = false;
            isTouch = true;
            player.moveDir = PlayerMoveComponent.InputMove.None;
            player.SnapToNearest();
            Debug.Log("Skolko raz ebal  mamu");

        }
        if(collision.GetComponent<Enemy>() != null)
        {
            if (player.isMove)
            {
                player.transform.position = collision.transform.position;
                collision.GetComponent<Enemy>().Die();
                SceneController.isEnemyTurn = true;
                player.isMove = false;
                isActive = false;
            player.moveDir = PlayerMoveComponent.InputMove.None;
            }
            // else
            // {
            //     Destroy(player.gameObject);
            // }
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
