using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI anyKeyText;
    [SerializeField] string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink());        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.anyKeyDown){
        SceneManager.LoadScene(nextScene);
       }
        

    }

    IEnumerator Blink(){
        while (true){
            anyKeyText.enabled = !anyKeyText.enabled;
            yield return new WaitForSeconds(0.8f);
        }        
    }
}
