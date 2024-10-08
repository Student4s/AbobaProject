using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneController : MonoBehaviour
{
    public static bool isMuted = false;
    [SerializeField] public bool isTurnBased = true;
    [SerializeField] AudioSource audioSource;
    public static bool isEnemyTurn;
    public static GameObject player;

    [SerializeField] private float timeBetweenTurns = 0.2f;
    [SerializeField] private float currentTimeBetweenTurns = 0;
    [SerializeField] private Image image;
    // Start is called before the first frame update
    void Start()
    {
        if(isMuted == true){
            audioSource.volume = 0;
        } else {
            audioSource.volume = 1;
        }

        isEnemyTurn = false;
        player = GameObject.Find("Player");//Find by name
        //Debug.Log(player.name);
    }
    private void Update()// delay between turns
    {
        if(isEnemyTurn)
        {
 //           Debug.Log(Time.deltaTime);
            currentTimeBetweenTurns += 10 * Time.deltaTime;
//            image.fillAmount = currentTimeBetweenTurns/ timeBetweenTurns;
            if(currentTimeBetweenTurns>= timeBetweenTurns)
            {
                currentTimeBetweenTurns = 0;
                isEnemyTurn = false;
            }

        }
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void SetMuted(){
        isMuted = !isMuted;
        if(isMuted == true){
            audioSource.volume = 0;
        } else {
            audioSource.volume = 1;
        }
    }

    public bool GetMuted(){ return isMuted; }
}
