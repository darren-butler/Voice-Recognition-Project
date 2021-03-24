using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time = 10;
    [SerializeField] private GameObject timerTextObject;
    public bool timeUp = false;

    // Start is called before the first frame update
    void Start()
    {
        timeUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!timeUp)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                DisplayTime(time);
            }
            else
            {
                time = -1;
                timeUp = true;
                DisplayTime(time);
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EndGame();
            }
        }
    }

    private void DisplayTime(float time)
    {
        time++;

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timerTextObject.GetComponent<TextMeshProUGUI>().text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }
}
