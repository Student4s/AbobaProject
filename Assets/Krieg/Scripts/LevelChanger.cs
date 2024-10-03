using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public void LoadMenu(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}
