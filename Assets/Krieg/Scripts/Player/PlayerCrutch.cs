using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrutch : MonoBehaviour// what player touch
{
    public bool isActive = false;
    public bool isTouch = false;
    [SerializeField] private PlayerMoveComponent player;
    private SceneController sctrl;

    void Start(){
        isActive = false;
        GameObject targetObject = GameObject.Find("SceneController");
        sctrl = targetObject.GetComponent<SceneController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isActive && collision.CompareTag("Wall")){
            isTouch = true;
        } 
        if(isActive){
        if(collision.CompareTag("Wall"))
        {
            SceneController.isEnemyTurn = true;
            player.isMove = false;
            isActive = false;
            isTouch = true;
            // player.moveDir = PlayerMoveComponent.InputMove.None;
            player.SnapToNearest();
            //Debug.Log("Skolko raz ebal  mamu");
            SceneController.turnCounter += 1;
           sctrl.PlayWallBumpSound();
        }
        if(collision.GetComponent<Enemy>() != null)
        {
            if (player.isMove)
            {
            // StartCoroutine(SceneController.FreezeGame());
                sctrl.PlayHitSound();           
                player.transform.position = collision.transform.position;
                collision.GetComponent<Enemy>().Die();
                SceneController.isEnemyTurn = true;
                player.isMove = false;
                isActive = false;
            player.moveDir = PlayerMoveComponent.InputMove.None;
            SceneController.turnCounter += 1;
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
