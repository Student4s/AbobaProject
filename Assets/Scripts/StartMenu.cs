using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{

    // [SerializeField] TextMeshProUGUI anyKeyText;
    [SerializeField] string nextScene;
    [SerializeField] TextMeshProUGUI playButtonText;
    [SerializeField] TextMeshProUGUI soundButtonText;
    private SceneController sceneController;
    // Start is called before the first frame update



    void Start()
    {
        sceneController = GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        //    if (Input.anyKeyDown){
        //     SceneManager.LoadScene(nextScene);
        //    }
    }

    public void OnSound()
    {

        sceneController.SetMuted();
        if (sceneController.GetMuted() == true)
        {
            soundButtonText.text = "Sound: Off";
        }
        else
        {
            soundButtonText.text = "Sound: On";
        }
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(nextScene);
    }

    // IEnumerator Blink(){
    //     while (true){
    //         anyKeyText.enabled = !anyKeyText.enabled;
    //         yield return new WaitForSeconds(0.8f);
    //     }        
    // }
}
