using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("you picked up a coin!");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>().UpdateScore(coinValue);
        Destroy(gameObject);
    }
}
