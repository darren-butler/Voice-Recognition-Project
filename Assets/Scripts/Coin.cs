using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("you picked up a coin!");
        ScoreText.coinCount += 1;
        Destroy(gameObject);
    }
}
