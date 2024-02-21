using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityTracery;
using Random = UnityEngine.Random;

public class GenerateText : MonoBehaviour
{
    public TextAsset[] bmanIntros;
    public TextAsset[] playerPoss;
    public TextAsset[] playerNegs;
    public TextAsset[] bmanResps;
    
    private TextAsset businessmanIntro;
    private TextAsset playerPos;
    private TextAsset playerNeg;
    private TextAsset bmanResp;

    private TraceryGrammar Grammar;
    
    //UI Elements
    public TextMeshProUGUI bmanBox;
    public TextMeshProUGUI playerPosBox;
    public TextMeshProUGUI playerNegBox;
    public Button posButton;
    public Button negButton;
    
    //typewriter effect vars
    public float delay = 0.1f;
    private string fullText;
    private string currentText = "";
    
    
    //vars for continuing the game
    public GameObject player;
    public GameObject UICamera;
    public GameObject _canvas;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        ShuffleText();
        posButton.gameObject.SetActive(false);
        negButton.gameObject.SetActive(false);
        UpdateGrammar(businessmanIntro.text);
        GenerateOutput(bmanBox);
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

            if (i == fullText.Length - 1)
            {
                ShowButtons();
                ShuffleText();
            }
        }
    }
    private void ShowButtons()
    {
        UpdateGrammar(playerPos.text);
        var output = Grammar.Generate();
        playerPosBox.text = output;
        UpdateGrammar(playerNeg.text);
        output = Grammar.Generate();
        playerNegBox.text = output;
        
        posButton.gameObject.SetActive(true);
        negButton.gameObject.SetActive(true);
    }

    public void ShuffleText()
    {
        businessmanIntro = bmanIntros[Random.Range(0, bmanIntros.Length)];
        playerPos = playerPoss[Random.Range(0, playerPoss.Length)];
        playerNeg = playerNegs[Random.Range(0, playerNegs.Length)];
        bmanResp = bmanResps[Random.Range(0, bmanResps.Length)];
    }

    public void PositiveButtonPress()
    {
        posButton.gameObject.SetActive(false);
        negButton.gameObject.SetActive(false);
        ShuffleText();
        UpdateGrammar(bmanResp.text);
        GenerateOutput(bmanBox);
    }

    public void NegativeButtonPress()
    {
        Time.timeScale = 1;
        player.SetActive(true);
        UICamera.SetActive(false);
        _canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
