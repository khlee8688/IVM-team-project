using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour, IInteractable
{
    GameObject[] NPC;
    [SerializeField] GameObject Script;
    Shim_BackScript backScript;
    public int QuestNumber; // 총 퀘스트의 개수
    public int[] QuestIndex;

    // public int[] QuestIndex; 여기에 저장된 것들을 스택으로 변환한 변수
    // QuestIndex에 0, 1, 3 이렇게 3개의 숫자가 들어있었다면, 스택에는 3, 1, 0 순서대로 들어있고,
    // 스택에서 값을 사용할때 0이 먼저, 그 다음이 1, 그 다음은 3이 사용되도록 하라.
    // 선언만 여기서 하고 초기화는 Start에서 하라.
    // 그리고 QuestManager를 참조하는 다른 클래스에서 사용할 수 있도록 Getter도 만들어라.
    // 그러고 큐 최상단 값을 제거하는 함수, 

    private int SuccessQuestNumber; // 성공한 퀘스트의 개수

    // Start is called before the first frame update
    void Start()
    {
        NPC = GameObject.FindGameObjectsWithTag("NPC");
        SuccessQuestNumber = 0;
        backScript = Script.GetComponent<Shim_BackScript>();
        if (backScript != null)
        {
            // QuestIndex 배열의 크기를 QuestNumber로 설정
            // 1부터 backScript.GetSentencesLength()-1까지의 숫자 중 QuestIndex 배열의 크기만큼 숫자 고르기
            // 고른 숫자들 오름차순으로 정렬해서 QuestIndex에 넣기
            QuestIndex = SelectUniqueQuestIndices(QuestNumber, backScript.GetSentencesLength());
        }
        Debug.Log("QuestIndex is");
        foreach (int n in QuestIndex)
        {
            Debug.Log(n);
        }
        Debug.Log("----------");

    }

    // private int[] SelectUniqueQuestIndices(int count, int maxIndex)
    // {
    //     // Ensure we don't try to select more indices than available
    //     count = Mathf.Min(count, maxIndex);

    //     // Use LINQ to select unique random indices and sort them
    //     return Enumerable.Range(1, maxIndex)
    //         .OrderBy(x => UnityEngine.Random.value)
    //         .Take(count)
    //         .OrderBy(x => x)
    //         .ToArray();
    // }
    private int[] SelectUniqueQuestIndices(int count, int maxIndex)
    {
        // 1부터 시작하는 범위에서 고를 수 있는 숫자의 최대 개수 확인
        int availableCount = maxIndex;

        if (count > availableCount)
        {
            // 미션의 수가 인덱스의 수보다 많은 경우, 모든 인덱스를 선택
            Debug.LogWarning($"Mission count ({count}) exceeds available indices ({availableCount}). Selecting all available indices.");
            QuestNumber = availableCount; // 선택할 미션의 수를 가능한 인덱스 수로 수정
            return Enumerable.Range(1, availableCount).ToArray();
        }

        // LINQ를 사용해 고유한 랜덤 인덱스를 선택하고 정렬
        return Enumerable.Range(1, availableCount)
            .OrderBy(x => UnityEngine.Random.value)
            .Take(count)
            .OrderBy(x => x)
            .ToArray();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteract(int QuestType)
    {
        Debug.Log("QuestManager OnInteract(int QuestType) function is called");
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
        Debug.Log("QuestManager OnInteract() function is called");
    }

    public int GetSuccessQuestNumber()
    {
        return SuccessQuestNumber;
    }

    public void AddOneToSuccessQuestNumber()
    {
        SuccessQuestNumber++;
    }
    public void IncrementSuccessQuestNumber()
    {
        SuccessQuestNumber++;
    }
}
