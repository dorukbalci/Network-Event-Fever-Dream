using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityTracery;

public class GenerateText : MonoBehaviour
{
    public TextAsset businessmanIntro;
    public TextAsset playerPos;
    public TextAsset playerNeg;

    public TraceryGrammar Grammar;
    public TextMeshProUGUI bmanText;
    public TextMeshProUGUI playerPosText;
    public TextMeshProUGUI playerNegText;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        UpdateGrammar(businessmanIntro.text);
        GenerateOutput(bmanText);
        
        UpdateGrammar(playerPos.text);
        GenerateOutput(playerPosText);
        
        UpdateGrammar(playerNeg.text);
        GenerateOutput(playerNegText);
    }

    public void UpdateGrammar(string grammartext) {
        Grammar = new TraceryGrammar(grammartext);
    }
    
    public void GenerateOutput(TextMeshProUGUI textOutput)
    {
        var output = Grammar.Generate();
        textOutput.text = output;
    }
}
