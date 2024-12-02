using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackScript : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public string script;
    private int scriptIndex = 0;
    private string[] sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = script.Split('.');
        text.text = sentences[scriptIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextString(){
        scriptIndex++;
        if(scriptIndex < sentences.Length){
            text.text = sentences[scriptIndex];
        }
        else{
            StringEnd();
        }
    }

    void StringEnd(){

    }
}
