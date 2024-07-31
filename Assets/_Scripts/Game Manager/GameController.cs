using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : ZuMonoBehaviour
{
    [SerializeField] protected static GameController instance;
    public static GameController Instance => instance;

    [SerializeField] protected GameObject gameOverUI;
    [SerializeField] protected GameObject victoryUI;
    public bool isGameOver = false;

    protected override void Awake()
    {
        base.Awake();
        if(instance == null)
        {
            GameController.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadGameOverUI();
        this.LoadVictoryGameUI();
    }

    protected virtual void LoadGameOverUI()
    {
        if (this.gameOverUI != null) return;
        this.gameOverUI = GameObject.Find("Game Over UI");
        this.gameOverUI.SetActive(false);
        Debug.Log(transform.name + ": LoadGameOverUI", gameObject);
    }

    protected virtual void LoadVictoryGameUI()
    {
        if (this.victoryUI != null) return;
        this.victoryUI = GameObject.Find("Victory UI");
        this.victoryUI.SetActive(false);
        Debug.Log(transform.name + ": LoadVictoryGameUI", gameObject);
    }

    public virtual void GameOver()
    {
        this.isGameOver = true;
        StartCoroutine(GameOverDelay());
    }

    public virtual void VictoryGame()
    {
        StartCoroutine(VictoryGameDelay());
    }

    private IEnumerator VictoryGameDelay()
    {
        yield return new WaitForSeconds(10);
        this.victoryUI.SetActive(true);
    }

    private IEnumerator GameOverDelay()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(3);
        yield return waitForSeconds;
        this.gameOverUI.SetActive(true);
    }
}
