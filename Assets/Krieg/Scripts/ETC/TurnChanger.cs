using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnChanger : MonoBehaviour
{
    public static bool isEnemyTurn;
    public static GameObject player;

    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private float currentTimeBetweenTurns;
    [SerializeField] private Image image;


    private void Start()
    {
        isEnemyTurn = false;
        player = GameObject.Find("Player");//Find by name
        //Debug.Log(player.name);
    }
    private void Update()// delay between turns
    {
        if(isEnemyTurn)
        {
            currentTimeBetweenTurns += Time.deltaTime;
            image.fillAmount = currentTimeBetweenTurns/ timeBetweenTurns;
            if(currentTimeBetweenTurns>= timeBetweenTurns)
            {
                currentTimeBetweenTurns = 0;
                isEnemyTurn = false;
            }

        }
    }
}
