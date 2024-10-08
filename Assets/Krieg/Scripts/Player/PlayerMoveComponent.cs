using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveComponent : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] public bool isTurnBased;
    [SerializeField] private SceneController sctrl;

    public bool isMove;

    public enum InputMove {None, Up, Down, Left, Right};
    public InputMove moveDir;
    public float currentTime = 0;
    public float timeBuffer = 0.5f;

    [SerializeField] private PlayerCrutch top;
    [SerializeField] private PlayerCrutch bot;
    [SerializeField] private PlayerCrutch right;
    [SerializeField] private PlayerCrutch left;

    public bool aTop, aBot, aLeft, aRight;

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

    public void Restart(){
        transform.position = startPos;
        isMove = false;
        gameObject.SetActive(true);
        moveDir = InputMove.None;
    }

    void Start(){
        startPos = transform.position;
        isTurnBased = sctrl.isTurnBased;
    }

    void Update()
    {
        aTop = top.isActive; aBot = bot.isActive; aLeft = left.isActive; aRight = right.isActive;
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

        if((currentTime += Time.deltaTime) >= timeBuffer){
            moveDir = InputMove.None;
            currentTime = 0;
        }

        if(!isMove){
            switch(moveDir){
                case InputMove.Up: MoveTop(); break;
                case InputMove.Down: MoveBot(); break;
                case InputMove.Left: MoveLeft(); break;
                case InputMove.Right: MoveRight(); break;
                case InputMove.None: break;
            }
        } else {
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    public void MoveTop()
    {
        if(!isMove)
        {
            if (!top.isTouch)
            {
                if (!SceneController.isEnemyTurn || !isTurnBased)
                {
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

    public void SnapToNearest(){
        isMove = false;

         Vector3 currentPosition = transform.position;

        // Snap each axis to the nearest 0.5 value
        float snappedX = Mathf.Round(currentPosition.x * 2) / 2;
        float snappedY = Mathf.Round(currentPosition.y * 2) / 2;
        float snappedZ = Mathf.Round(currentPosition.z * 2) / 2;

        // Set the position of the GameObject
        transform.position = new Vector3(snappedX, snappedY, snappedZ);
    }

}
