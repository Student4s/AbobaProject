using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveComponent : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0f;
    public float maxSpeed = 24f;
    public float minSpeed = 4f;
    public float acceleration = 6f;
    [SerializeField] public bool isTurnBased;
    [SerializeField] private SceneController sctrl;
    private BoxCollider2D collider2D;
    private LevelManager lvlmng;
    private Coroutine deathCoroutine;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public bool isMove;
    public bool isAttacking = false;
    public bool isIdle = false;
    public bool isDying = false;
    public bool facingUp = false;
    public bool facingDown = false;

    public enum InputMove { None, Up, Down, Left, Right };
    public InputMove moveDir;
    public float currentTime = 0;
    public float timeBuffer = 0.4f;
    int triggerCount = 0;

    [SerializeField] private PlayerCrutch top;
    [SerializeField] private PlayerCrutch bot;
    [SerializeField] private PlayerCrutch right;
    [SerializeField] private PlayerCrutch left;

    //public bool aTop, aBot, aLeft, aRight;

    public Vector2 direction;
    public Vector3 startPos;

    private void OnEnable()
    {
        Crutch.Change += ChangeTurn;
    }
    private void OnDisable()
    {
        Crutch.Change -= ChangeTurn;
    }

    public void Restart()
    {
        transform.position = startPos;
        isMove = false;
        gameObject.SetActive(true);
        moveDir = InputMove.None;

        top.isActive = bot.isActive = right.isActive = left.isActive = false;

        //        animator.SetBool("isDead", false);
        collider2D.enabled = true;
        lvlmng.SetOver(false);
        //animator.Play("idle");
    }

    void Start()
    {
        startPos = transform.position;
        isTurnBased = sctrl.isTurnBased;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();
        
        GameObject target = GameObject.Find("LevelManager");
        lvlmng = target.GetComponent<LevelManager>();
    }

    void Update()
    {
        if (!isAttacking)
        {
            //aTop = top.isActive; aBot = bot.isActive; aLeft = left.isActive; aRight = right.isActive;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveDir = InputMove.Up;
                currentTime = 0;
                //MoveTop();
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveDir = InputMove.Down;
                currentTime = 0;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moveDir = InputMove.Left;
                currentTime = 0;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                moveDir = InputMove.Right;
                currentTime = 0;
            }

            if ((currentTime += Time.deltaTime) >= timeBuffer)
            {
                moveDir = InputMove.None;
                currentTime = 0;
            }

            if (!isMove)
            {
                if (!isDying)
                {
                    if (facingDown)
                    {
                        animator.Play("idle_down");
                    }
                    else if (facingUp)
                    {
                        animator.Play("idle_up");
                    }
                    else
                    {
                        animator.Play("idle");
                    }
                }
                moveSpeed = minSpeed;
                switch (moveDir)
                {
                    case InputMove.Up: MoveTop(); break;
                    case InputMove.Down: MoveBot(); break;
                    case InputMove.Left: MoveLeft(); break;
                    case InputMove.Right: MoveRight(); break;
                    case InputMove.None: break;
                }
            }
            else
            {
                animator.SetBool("isRolling", true);

                moveSpeed += (maxSpeed - moveSpeed) * acceleration * Time.deltaTime;
                moveSpeed = Mathf.Clamp(moveSpeed, 0f, maxSpeed);
                // Debug.Log(moveSpeed);
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
        }

        triggerCount = 0;

        if (top.isTouch) triggerCount++;
        if (bot.isTouch) triggerCount++;
        if (left.isTouch) triggerCount++;
        if (right.isTouch) triggerCount++;

        // If three triggers are active, adjust the position
        if (triggerCount >= 3)
        {
            Vector3 adjustment = Vector3.zero;

            // Check which trigger is not active and adjust position accordingly
            if (!top.isTouch)
            {
                adjustment = new Vector3(0, 0.5f, 0);  // Move up
            }
            else if (!bot.isTouch)
            {
                adjustment = new Vector3(0, -0.5f, 0); // Move down
            }
            else if (!left.isTouch)
            {
                adjustment = new Vector3(-0.5f, 0, 0); // Move left
            }
            else if (!right.isTouch)
            {
                adjustment = new Vector3(0.5f, 0, 0);  // Move right
            }

            // Apply the adjustment to the object position
            transform.position += adjustment;

            Debug.Log("fixed?");
        }
    }

    public void MoveTop()
    {
        if (!isMove)
        {
            if (!top.isTouch)
            {
                if (!SceneController.isEnemyTurn || !isTurnBased)
                {
                    facingDown = false;
                    facingUp = true;
                    animator.Play("move_up");

                    //                    animator.SetBool("directionDown", false);
                    top.isActive = true;
                    isMove = true;
                    direction = -Vector2.down;
                }
            }
        }
    }
    public void MoveLeft()
    {
        if (!isMove)
        {
            if (!left.isTouch)
            {
                if (!SceneController.isEnemyTurn || !isTurnBased)
                {
                    facingDown = false;
                    facingUp = false;
                    animator.Play("move");
                    //animator.SetBool("directionUp", false);
                    //animator.SetBool("directionDown", false);
                    spriteRenderer.flipX = true;
                    left.isActive = true;
                    isMove = true;
                    direction = Vector2.left;
                }
            }
        }
    }
    public void MoveBot()
    {
        if (!isMove)
        {
            if (!bot.isTouch)
            {
                if (!SceneController.isEnemyTurn || !isTurnBased)
                {
                    facingDown = true;
                    facingUp = false;
                    animator.Play("move_down");

                    //animator.SetBool("directionDown", true);
                    //animator.SetBool("directionUp", false);
                    bot.isActive = true;
                    isMove = true;
                    direction = Vector2.down;
                }
            }
        }
    }
    public void MoveRight()
    {
        if (!isMove)
        {
            if (!right.isTouch)
            {
                if (!SceneController.isEnemyTurn || !isTurnBased)
                {
                    facingDown = false;
                    facingUp = false;
                    animator.Play("move");

                    //animator.SetBool("directionUp", false);
                    //animator.SetBool("directionDown", false);
                    spriteRenderer.flipX = false;
                    right.isActive = true;
                    isMove = true;
                    direction = Vector2.right;
                }
            }
        }
    }

    public void ChangeTurn()
    {
        SceneController.isEnemyTurn = false;
    }

    public void SnapToNearest()
    {
        isMove = false;

        Vector3 currentPosition = transform.position;

        // Snap each axis to the nearest 0.5 value
        float snappedX = Mathf.Round(currentPosition.x * 2) / 2;
        float snappedY = Mathf.Round(currentPosition.y * 2) / 2;
        float snappedZ = Mathf.Round(currentPosition.z * 2) / 2;

        // Set the position of the GameObject
        transform.position = new Vector3(snappedX, snappedY, snappedZ);

        // Count how many triggers are active


    }

    public void AnimationAttack()
    {
        isAttacking = true;
        //animator.Play("attack_side");
        //animator.SetBool("isRolling", false);
        //animator.SetBool("isAttacking", true);
        if (facingDown)
        {
            animator.Play("attack_down");
        StartCoroutine(ResetAttack("attack_down"));
        }
        else if (facingUp)
        {
            animator.Play("attack_up");
        StartCoroutine(ResetAttack("attack_up"));
        }
        else
        {
            animator.Play("attack_side");
        StartCoroutine(ResetAttack("attack_side"));
        }
        // animator.SetTrigger("Attacking");
    }

    public IEnumerator ResetAttack(string name)
    {
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
        collider2D.enabled = false;
        isMove = false;
        moveDir = InputMove.None;
        // animator.SetBool("isDead", true);
        //animator.SetTrigger("Dying");

        animator.Play("death");
        StartCoroutine(ResetDeath());
        //gameObject.SetActive(false);

        /// Text

    }
    public IEnumerator ResetDeath()
    {
        isDying = true;
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
        gameObject.SetActive(false);
        isDying = false;
        lvlmng.SetOver(true);
    }

}
