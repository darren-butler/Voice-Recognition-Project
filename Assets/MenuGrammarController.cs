using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MenuGrammarController : MonoBehaviour
{
    private GrammarRecognizer gr;
    [SerializeField] private MainMenu mm;


    // Start is called before the first frame update
    void Start()
    {
        

        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, "Grammar.xml"), ConfidenceLevel.Low);
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
        foreach (SemanticMeaning meaning in meanings)
        {
            string keyString = meaning.key.Trim();
            string valueString = meaning.values[0].Trim();
            message.Append("Key: " + keyString + " , Value: " + valueString + " ");


            switch (valueString)
            {
                case "play":
                    mm.Play();
                    break;
                case "quit":
                    mm.Quit();
                    break;
                default:
                    break;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
