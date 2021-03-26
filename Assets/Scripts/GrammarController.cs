using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class GrammarController : MonoBehaviour
{

    private GrammarRecognizer gr;
    public GameObject character;
    private AlienController alienController;

    // Start is called before the first frame update
    void Start()
    {
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath , "Grammar.xml"), ConfidenceLevel.Low);
        Debug.Log("Grammar Loaded");
        gr.OnPhraseRecognized += Gr_OnPhraseRecognized;
        gr.Start();
        if (gr.IsRunning) 
            Debug.Log("Recognizer Running");
    }

    private void Gr_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder message = new StringBuilder();
        SemanticMeaning[] meanings = args.semanticMeanings;

        foreach(SemanticMeaning meaning in meanings)
        {
            string keyString = meaning.key.Trim();
            string valueString = meaning.values[0].Trim();

            message.Append($"({keyString}: {valueString}), ");

            if(keyString == "action" && valueString == "move")
            {
                MoveCommand(meanings);
            }

            if (keyString == "action" && valueString == "hide")
            {
                HideCommand(meanings);
            }

        }

        Debug.Log(message);
    }

    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= Gr_OnPhraseRecognized;
            gr.Stop();
        }
    }

    private void HideCommand(SemanticMeaning[] meanings)
    {
        StringBuilder message = new StringBuilder();
        string alien = null;
        string direction = null;
        string distance = null;

        foreach (SemanticMeaning meaning in meanings)
        {
            if (meaning.key.Trim() == "alien")
            {
                alien = meaning.values[0].Trim();
            }
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<AlienController>().HideAlien(alien);
    }

    private void MoveCommand(SemanticMeaning[] meanings)
    {
        StringBuilder message = new StringBuilder();
        string alien = null;
        string direction = null;
        string distance = null;

        foreach (SemanticMeaning meaning in meanings)
        {
            //string keyString = meaning.key.Trim();
            //string valueString = meaning.values[0].Trim();
            //message.Append($"({keyString}: {valueString}), ");

            if(meaning.key.Trim() == "alien")
            {
                alien = meaning.values[0].Trim();
            }

            if(meaning.key.Trim() == "direction")
            {
                direction = meaning.values[0].Trim();
            }

            if (meaning.key.Trim() == "distance")
            {
                distance = meaning.values[0].Trim();
            }

        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<AlienController>().MoveAlien(alien, direction, Int32.Parse(distance));

        //Debug.Log($"alien:{alien}, direction:{direction}");

    }
}
