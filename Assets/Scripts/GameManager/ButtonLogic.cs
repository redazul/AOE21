using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonLogic : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();

    }


    public void BeginGame()
    {
        SceneManager.LoadScene(1);
    }
}
