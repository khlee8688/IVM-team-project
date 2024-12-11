using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour, IInteractable
{
    GameObject[] NPC;
    public int QuestNumber; // 총 퀘스트의 개수
    int SuccessQuestNumber; // 성공한 퀘스트의 개수

    // Start is called before the first frame update
    void Start()
    {
        NPC = GameObject.FindGameObjectsWithTag("NPC");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteract(int QuestType)
    {
        // NPC가 QuestType 값에 따른 행동을 하도록 이벤트 발생

        if (NPC.Length == 0)
        {
            Debug.LogWarning("No NPCs found in the scene.");
            return;
        }

        // 랜덤으로 NPC 배열에서 하나 선택
        int randomIndex = Random.Range(0, NPC.Length);
        GameObject selectedNPC = NPC[randomIndex];

        // 선택된 NPC와 관련된 작업 수행
        Debug.Log($"Randomly selected NPC: {selectedNPC.name} for QuestType {QuestType}");

        // 예: 선택된 NPC에게 퀘스트 전달
        var npcInteractable = selectedNPC.GetComponent<IInteractable>();
        if (npcInteractable != null)
        {
            npcInteractable.OnInteract(QuestType);
        }
        else
        {
            Debug.LogWarning($"Selected NPC {selectedNPC.name} does not implement IInteractable.");
        }
    }

    public void OnInteract()
    {
        // 단순 이벤트 전달, 
    }
}
