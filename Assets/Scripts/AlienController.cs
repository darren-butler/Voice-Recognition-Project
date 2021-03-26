using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    [SerializeField] private GameObject green;
    [SerializeField] private GameObject pink;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideAlien(string alien)
    {
        switch (alien)
        {
            case "green":
                green.GetComponent<Movement>().Hide();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<SoundController>().PlayShieldSound();
                break;
            case "pink":
                pink.GetComponent<Movement>().Hide();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<SoundController>().PlayShieldSound();
                break;
            default:
                break;
        }
    }

    public void MoveAlien(string alien, string direction, int distance)
    {
        switch (alien)
        {
            case "green":
                green.GetComponent<Movement>().Move(direction, distance);
                break;
            case "pink":
                pink.GetComponent<Movement>().Move(direction, distance);
                break;
            default:
                break;
        }
    }
}
