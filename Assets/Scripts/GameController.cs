using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool gameOver = false;
    private int playerScore;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        IsGameOver();
    }

    private void IsGameOver()
    {
        if(gameObject.GetComponent<Timer>().timeUp)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        Debug.Log("GAME OVER!");
        FindObjectOfType<CoinSpawner>().GetComponent<CoinSpawner>().DisableSpawning();

        gameObject.GetComponent<GameOverMenu>().GameOver();
    }

    private void OnEnable()
    {
        FindObjectOfType<CoinSpawner>().GetComponent<CoinSpawner>().EnableSpawning();
    }

}
