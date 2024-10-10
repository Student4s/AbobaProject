using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    private Enemy[] enemies;
    public int enemiesNum;
    // public GameObject spawnObj;
    public Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        // spawnObj = gameObject.transform.Find("SpawnPoint");
        spawnPos = gameObject.transform.Find("SpawnPoint");
        enemies = GetComponentsInChildren<Enemy>();
        enemiesNum = enemies.Length;
        //  spawnPos =  spawnObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.Restart();
        }
        enemiesNum = enemies.Length;
    }
}
