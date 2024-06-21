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
            GameController.Instance.isGameOver = false;
            SceneManager.LoadScene(1);

        }
    }
}
