using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string MainScene;
   
    public void ChangeS()
    {
        SceneManager.LoadScene(MainScene);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
