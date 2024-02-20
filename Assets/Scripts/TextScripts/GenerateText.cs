using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityTracery;

public class GenerateText : MonoBehaviour
{
    public TextAsset businessmanIntro;
    public TextAsset playerPos;
    public TextAsset playerNeg;

    public TraceryGrammar Grammar;
    public TextMeshProUGUI bmanBox;
    public TextMeshProUGUI playerPosBox;
    public TextMeshProUGUI playerNegBox;
    
    //typewriter effect vars
    public float delay = 0.1f;
    private string fullText;
    private string currentText = "";
    
    // Start is called before the first frame update
    void OnEnable()
    {
        UpdateGrammar(businessmanIntro.text);
        GenerateOutput(bmanBox);
        
        UpdateGrammar(playerPos.text);
        GenerateOutput(playerPosBox);
        
        UpdateGrammar(playerNeg.text);
        GenerateOutput(playerNegBox);
    }

    public void UpdateGrammar(string grammartext) {
        Grammar = new TraceryGrammar(grammartext);
    }
    
    public void GenerateOutput(TextMeshProUGUI textBlock)
    {
        var output = Grammar.Generate();
        fullText = output;
        StartCoroutine(ShowText(textBlock));
        //textBlock.text = output;
    }

    IEnumerator ShowText(TextMeshProUGUI textBlock)
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textBlock.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

  
    
}
