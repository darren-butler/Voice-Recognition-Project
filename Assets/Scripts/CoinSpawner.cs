using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public delegate void CoinSpawned();
    public static event CoinSpawned CoinSpawnedEvent;


    [SerializeField] private Coin coinPrefab;
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private float spawnInterval = 5f;

    private GameObject coinParent;
    private const string SPAWN_COIN_METHOD = "SpawnCoin";

    // Start is called before the first frame update
    void Start()
    {
        coinParent = GameObject.Find("Coins");
        if(!coinParent)
        {
            coinParent = new GameObject("Coins");
        }
    }

    public void EnableSpawning()
    {
        InvokeRepeating(SPAWN_COIN_METHOD, spawnDelay, spawnInterval);
    }

    public void DisableSpawning()
    {
        CancelInvoke(SPAWN_COIN_METHOD);
    }

    private void SpawnCoin()
    {
        var coin = Instantiate(coinPrefab, coinParent.transform);

        int x = Random.Range(-8, 9);
        int y = Random.Range(-4, 5);

        coin.transform.position = new Vector3(x,y,0f);
        PublishCoinSpawnedEvent();

        Debug.Log("spawned coin!");
    }

    public void PublishCoinSpawnedEvent()
    {
        CoinSpawnedEvent?.Invoke();
    }
}
