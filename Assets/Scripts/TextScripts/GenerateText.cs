using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityTracery;

public class GenerateText : MonoBehaviour
{
    public TextAsset businessmanIntro;
    
    
    public TraceryGrammar Grammar;
    public TextMeshProUGUI TextOutput;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        UpdateGrammar();
        GenerateOutput();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateGrammar() {
        Grammar = new TraceryGrammar(businessmanIntro.text);
    }
    
    public void GenerateOutput()
    {
        var output = Grammar.Generate();
        TextOutput.text = output;
    }
}
