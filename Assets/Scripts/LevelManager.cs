using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
 
    public int currentLevel = 0;
    [SerializeField] public Level[] levels;
    //[SerializeField] GameObject playerObj;
    [SerializeField] PlayerMoveComponent playerMov;
    [SerializeField] Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {

        GameObject playerObj = GameObject.Find("SpawnPoint");

        //playerMov = GetComponent<PlayerMoveComponent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            playerMov.Restart();
            levels[currentLevel].Restart();
        }

        if(levels[currentLevel].enemiesNum == 0 && currentLevel + 1 < levels.Length){
            currentLevel += 1;
            Debug.Log(currentLevel);
            playerMov.startPos = levels[currentLevel].spawnPos.transform.position; // SHUE
        
            playerMov.Restart();
            levels[currentLevel].Restart();

            Vector3 newCam = levels[currentLevel].transform.position;
            newCam.z = -10;
            mainCamera.transform.position = newCam; 
        }   
    }
}
