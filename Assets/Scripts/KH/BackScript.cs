using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackScript : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Button menuButton;
    public string script;
    private int scriptIndex = 0;
    private string[] sentences;

    // Start is called before the first frame update
    void Start()
    {
        menuButton.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScript(string str){
        script = str;
        sentences = script.Split(". ");
        scriptIndex = 0;
        text.text = sentences[scriptIndex];
        text.gameObject.SetActive(true);
    }

    public void PreviousSentence(){
        if(scriptIndex > 0) scriptIndex--;
        text.text = sentences[scriptIndex];
    }

    public void NextSentence(){
        //when you press button A
        scriptIndex++;
        if(scriptIndex < sentences.Length){
            text.text = sentences[scriptIndex];
        }
        else{
            ScriptEnd();
        }
    }

    void ScriptEnd(){
        text.text = "Script is finished! Congratulations~";
        menuButton.gameObject.SetActive(true);
    }
}
