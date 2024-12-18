using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

public class Audience : MonoBehaviour, IInteractable
{
    bool isMissionTriggered;
    // [SerializeField] private Animator animator;
    Animator animator;
    [SerializeField] QuestManager questManager;
    public int QuestTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this GameObject.");
        }
        isMissionTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteract(int QuestType)
    {
        this.gameObject.SetActive(true);
        Debug.Log("Audience: " + this.name + ", OnInteract function called, QuestType is " + QuestType);

        // // int 값을 EnumQuestType으로 변환
        // if (!Enum.IsDefined(typeof(EnumQuestType), QuestType))
        // {
        //     Debug.LogWarning($"Invalid quest type value: {QuestType}");
        //     return;
        // }

        // EnumQuestType equestsType = (EnumQuestType)QuestType;

        // Enum 값에 따라 동작 실행
        // switch (equestsType)
        // {
        //     case EnumQuestType.RaiseHand:
        //         Debug.Log("RaiseHand quest activated.");
        //         HandleRaiseHandQuest(); // isMissionTriggered을 true로 바꿈
        //         break;

        //     case EnumQuestType.ClapHands:
        //         Debug.Log("ClapHands quest activated.");
        //         HandleClapHandsQuest();
        //         break;

        //     case EnumQuestType.LookSide:
        //         Debug.Log("Wave quest activated.");
        //         HandleLookSideQuest();
        //         break;

        //     default:
        //         Debug.LogWarning("Unknown quest type.");
        //         break;
        // }
        switch (QuestType)
        {
            case 1:
                Debug.Log("RaiseHand quest activated.");
                HandleRaiseHandQuest(); // isMissionTriggered을 true로 바꿈
                break;

            case 2:
                Debug.Log("ClapHands quest activated.");
                HandleClapHandsQuest();
                break;

            case 3:
                Debug.Log("Wave quest activated.");
                HandleLookSideQuest();
                break;

            default:
                Debug.LogWarning("Unknown quest type.");
                break;
        }
    }

    public void OnInteract()
    {
        if (isMissionTriggered)
        {
            // 추가 동작
            Debug.Log("Mission complete");
            questManager.AddOneToSuccessQuestNumber();
        }
    }

    private void SetAnimatorBool(bool idle, bool clap, bool lookSide, bool ask)
    {
        if (animator != null)
        {
            Debug.Log("SetBool functions are called");
            animator.SetBool("isIdle", idle);
            animator.SetBool("isClap", clap);
            animator.SetBool("isLookSide", lookSide);
            animator.SetBool("isAsking", ask);
        }
        else
        {
            Debug.Log("animator is not assigned");
        }
    }

    private void HandleRaiseHandQuest()
    {
        isMissionTriggered = true;
        // 손 들기 모션 처리 코드
        SetAnimatorBool(false, false, false, true);
        // QuestTime 시간 동안 대기, 이 변수는 에디터에서 값 할당, 5초로 가정 
        // 시간 지나면 isMissionTriggered를 false로 전환, BackToIdle() 함수 호출
        // 코루틴 시작: QuestTime 시간 후 아이들 상태로 돌아가기
        StartCoroutine(RaiseHandQuestTimer());
    }

    private IEnumerator RaiseHandQuestTimer()
    {
        // QuestTime 시간 동안 대기
        yield return new WaitForSeconds(QuestTime);

        // 시간이 지나면 아이들 상태로 복귀
        BackToIdle();

        // 미션 트리거 해제
        isMissionTriggered = false;
    }

    private void HandleClapHandsQuest()
    {
        // 박수 모션 처리 코드
        SetAnimatorBool(false, true, false, false);
    }

    private void HandleLookSideQuest()
    {
        // 주변 둘러보기 모션 처리 코드
        SetAnimatorBool(false, false, true, false);
    }

    private void BackToIdle()
    {
        SetAnimatorBool(true, false, false, false);
    }
}
