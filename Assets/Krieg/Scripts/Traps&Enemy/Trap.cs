using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    public enum TrapState { Active, Disabled }
    public TrapState currentState;
    [SerializeField] int offset = 1;
    [SerializeField] Sprite[] sprites;
    private SpriteRenderer rend;
    private SceneController sctrl;
    private PlayerMoveComponent playerMove;

    public void Start()
    {
        GameObject targetObj = GameObject.Find("SceneController");
        sctrl = targetObj.GetComponent<SceneController>();

        currentState = TrapState.Active;
        rend = GetComponent<SpriteRenderer>();


        targetObj = GameObject.Find("Player");
        playerMove = targetObj.GetComponent<PlayerMoveComponent>();
    }
    void Update()
    {
        if ((SceneController.turnCounter + offset) % 2 == 0 && currentState == TrapState.Disabled)
        {
            currentState = TrapState.Active;
            rend.color = new Color(0, 0, 1, 1);
        }
        else if ((SceneController.turnCounter + offset) % 2 != 0 && currentState == TrapState.Active)
        {
            currentState = TrapState.Disabled;
            rend.color = new Color(0, 0, 0.5f, 1);
        }
    }


    public virtual void ActivateTrap()
    {

        // StartCoroutine(SceneController.FreezeGame());
        playerMove.AnimationDeath();
        sctrl.PlayEnemyAttack();
        //SceneController.player.SetActive(false);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(SceneController.turnCounter);
        if (collision.gameObject.name == "Player" && currentState == TrapState.Active)
        {
            //Debug.Log("aboba");
            ActivateTrap();
        }


    }
}
