using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPos;
    private Level currentLevel;
    void Start (){
        startPos = transform.position;
        currentLevel = GetComponentInParent<Level>();
    }
   public void Die()
    {
        // Destroy(gameObject);
        gameObject?.SetActive(false);
        // ? is for null check

        currentLevel.enemiesNum -= 1;
    }

    public void Restart(){
        transform.position = startPos;
        gameObject?.SetActive(true);
    }

}
