using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] protected Animator transitionAnim;

    public virtual void OnStartGame()
    {
        StartCoroutine(this.LoadScene());
    }

    IEnumerator LoadScene()
    {
        this.transitionAnim.SetTrigger("End");

        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        yield return waitForSeconds;

        SceneManager.LoadScene(1);
        this.transitionAnim.SetTrigger("Start");
    }
}
