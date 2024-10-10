using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]    public EnemyTargetsMark top;
    [SerializeField] public EnemyTargetsMark bot;
    private Vector3 startPos;
    private Level currentLevel;
    private SceneController sctrl;
    private PlayerMoveComponent playerMove;
    public Animator animator;
    private bool isAttacking = false;

    

    public void Start()
    {
        startPos = transform.position;
        currentLevel = GetComponentInParent<Level>();
        GameObject targetObj = GameObject.Find("SceneController");
        sctrl = targetObj.GetComponent<SceneController>();
        targetObj = GameObject.Find("Player");
        playerMove = targetObj.GetComponent<PlayerMoveComponent>();

        animator = GetComponent<Animator>();
    }

    public void Update(){
        if (top.isTriggered == false && bot.isTriggered == false && !isAttacking){
            animator.Play("idle");
        }
    }

    public void AttackPlayer()
    {
        // StartCoroutine(SceneController.FreezeGame());

        //        Destroy(TurnChanger.player);
        playerMove.AnimationDeath();
        sctrl.PlayEnemyAttack();
        //SceneController.player.SetActive(false);
        // Debug.Log("Im attack");
    }// Start is called before the first frame update
    public void Die()
    {
        // Destroy(gameObject);

        AnimationDeath();
        gameObject?.SetActive(false);
        // ? is for null check

        currentLevel.enemiesNum -= 1;
    }

    public void Restart()
    {
        transform.position = startPos;
        gameObject?.SetActive(true);
    }
  public void AnimationAttack()
    {
        // isAttacking = true;
        //animator.Play("attack_side");
        if(top.isTriggered){
            Debug.Log("top");
        animator.Play("attack_top");
        StartCoroutine(ResetAttack("attack_top"));
        } else if (bot.isTriggered){
            Debug.Log("bot");
            animator.Play("attack_bot");
            StartCoroutine(ResetAttack("attack_bot"));
        }
       
       
        // animator.SetTrigger("Attacking");
    }

    public IEnumerator ResetAttack(string name)
    {
        isAttacking = true;
        // Get the animation state info for the base layer (index 0)
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Wait for the animation to finish
        // Ensure you're waiting for the specific animation's length
        while (!stateInfo.IsName(name))
        {
        // Debug.Log("biba egorov");
            // Keep checking until the animation starts
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            yield return null;
        }

        // Wait until the animation has finished
        yield return new WaitForSeconds(stateInfo.length);
        Debug.Log("aboba");


        
        //animator.SetBool("isAttacking", false);
        isAttacking = false;
        // Deactivate the GameObject after animation ends
    }

    public void AnimationDeath()
    {

        Debug.Log("mamu ebal");
        animator.Play("pawn_death");
        StartCoroutine(ResetDeath());
        //gameObject.SetActive(false);

        /// Text

    }
    public IEnumerator ResetDeath()
    {
        // isDying = true;
        // Get the animation state info for the base layer (index 0)
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Wait for the animation to finish
        // Ensure you're waiting for the specific animation's length
        while (!stateInfo.IsName("death"))
        {
            // Keep checking until the animation starts
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            yield return null;
            // animator.SetBool("isDead", false);
        }

        // Wait until the animation has finished
        yield return new WaitForSeconds(stateInfo.length);

        // Deactivate the GameObject after animation ends
        // gameObject.SetActive(false);
        // isDying = false;
        // lvlmng.SetOver(true);
    }
}
