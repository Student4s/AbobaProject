using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    
    public virtual void ActivateTrap()
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //Debug.Log("aboba");
            ActivateTrap();
        }
        

    }
}
