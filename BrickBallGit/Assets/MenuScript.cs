using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void LoadScene()
    {
       
       SceneManager.LoadScene("brickball");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
