using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;
    [SerializeField] private GameObject scoreTextObject;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int coinValue)
    {
        score += coinValue;
        scoreTextObject.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
