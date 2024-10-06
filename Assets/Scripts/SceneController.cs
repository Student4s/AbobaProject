using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static bool isMuted = false;
    [SerializeField] public bool isTurnBased = true;
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if(isMuted == true){
            audioSource.volume = 0;
        } else {
            audioSource.volume = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
