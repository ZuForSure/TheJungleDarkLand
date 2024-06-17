using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    public void ReloadScence()
    {
        if (GameController.Instance.isGameOver)
        {
            //Time.timeScale = 1;
            GameController.Instance.isGameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
