using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool gameOver;
    private int playerScore;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        gameOver = false;
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
        FindObjectOfType<CoinSpawner>().GetComponent<CoinSpawner>().DisableSpawning();
        gameObject.GetComponent<GameOverMenu>().GameOver();
    }

    private void OnEnable()
    {
        FindObjectOfType<CoinSpawner>().GetComponent<CoinSpawner>().EnableSpawning();
    }

}
