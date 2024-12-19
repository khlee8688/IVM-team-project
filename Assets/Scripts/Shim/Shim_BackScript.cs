using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using QuestSystem;

public class Shim_BackScript : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Button menuButton;
    [SerializeField] GameObject QuestManager;
    public GameObject timerObject;
    QuestManager questManager;
    public string script;
    private int scriptIndex = 0;
    private int currentMissionIndex = 0;
    private string[] sentences;

    // Start is called before the first frame update
    void Start()
    {
        questManager = QuestManager.GetComponent<QuestManager>();
        sentences = script.Split(". ");
        text.text = sentences[scriptIndex];
        menuButton.gameObject.SetActive(false);
        if (timerObject == null)
        {
            Debug.LogError("timerObject is not assigned");
            return;
        }
        else
        {
            StartTimer();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartTimer()
    {
        //InteractionManager.Instance.Interact(timer.gameObject);
        timerObject.GetComponent<Timer>().UpdateTriggerTime();
    }

    private void EndTimer()
    {
        //InteractionManager.Instance.Interact(timer.gameObject);
        timerObject.GetComponent<Timer>().UpdateTriggerTime();
    }

    public void PreviousSentence()
    {
        if (scriptIndex > 0) scriptIndex--;
        text.text = sentences[scriptIndex];
    }

    public void NextSentence()
    {
        //when you press button A
        scriptIndex++;
        Debug.Log("NextSentence function is called, scriptIndex is " + scriptIndex);
        if (scriptIndex < sentences.Length)
        {
            text.text = sentences[scriptIndex];
            // questManager에 있는 QuestIndex 배열의 값들을 
            Debug.Log("\tquestManager.QuestIndex.Length is " + questManager.QuestIndex.Length);
            Debug.Log("\tcurrentMissionIndex is " + currentMissionIndex);
            if (questManager.QuestIndex.Length > currentMissionIndex && scriptIndex == questManager.QuestIndex[currentMissionIndex])
            {
                Debug.Log("\tif Statement is true, InteractionManager.Instance.Interact(questManager.gameObject, 1); will be called");
                // InteractionManager.Instance.Interact(questManager.GameObject, 1);
                // InteractionManager.Instance.Interact(questManager.gameObject, EnumQuestType.RaiseHand);
                InteractionManager.Instance.Interact(questManager.gameObject, 1);
                currentMissionIndex++;
            }
            else
            {
                Debug.Log("\tif Statement is false");
            }
        }
        else
        {
            Debug.Log("\tScriptEnd will be called");
            ScriptEnd();
        }
    }

    void ScriptEnd()
    {
        // text.text = "Script is finished! Congratulations~";
        // menuButton.gameObject.SetActive(true);
        // if (questManager.GetSuccessQuestNumber() < questManager.QuestNumber)
        // {
        //     text.text = "Script is finished. But you didn't finish the missions. Try one more";
        // }
        // else
        // {
        //     text.text = "Script is finished! Congratulations~";
        // }
        EndTimer();
        float presentTime = timerObject.GetComponent<Timer>().GetTriggerIntervalTime();
        int elapsedSeconds = Mathf.FloorToInt(presentTime);
        int minutes = elapsedSeconds / 60;
        int seconds = elapsedSeconds % 60;
        // $"{minutes:D2}:{seconds:D2}";
        // text.text = "Script is finished! Congratulations~\n"
        //     + "Presented for " + minutes + " minutes " + seconds + " seconds.";
        text.text = "Script is finished! Congratulations~\n"
        + "Presented for " + minutes + " minutes " + seconds + " seconds.";
        menuButton.gameObject.SetActive(true);

        // menuButton.GetComponent<Collider>().SetActive(true);
    }

    public int GetSentencesLength()
    {
        return sentences.Length;
    }
}
