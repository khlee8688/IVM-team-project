using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

public class Audience : MonoBehaviour, IInteractable
{
    bool isMissionTriggered;
    [SerializeField] private Animator animator;
    public int QuestTime;

    // Start is called before the first frame update
    void Start()
    {
        isMissionTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteract(int QuestType)
    {
        // int 값을 EnumQuestType으로 변환
        if (!Enum.IsDefined(typeof(EnumQuestType), QuestType))
        {
            Debug.LogWarning($"Invalid quest type value: {QuestType}");
            return;
        }

        EnumQuestType equestsType = (EnumQuestType)QuestType;

        // Enum 값에 따라 동작 실행
        switch (equestsType)
        {
            case EnumQuestType.RaiseHand:
                Debug.Log("RaiseHand quest activated.");
                HandleRaiseHandQuest();
                break;

            case EnumQuestType.ClapHands:
                Debug.Log("ClapHands quest activated.");
                HandleClapHandsQuest();
                break;

            case EnumQuestType.LookSide:
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
            // HandleRaiseHandQuest()에서 isMissionTriggered이 true로 변하고,
            // QuestTime 시간이 아직 다 지나지 않아 isMissionTriggered이 다시 false로 변하지 않았다면
            // 
        }
    }

    private void SetAnimatorBool(bool idle, bool clap, bool lookSide, bool ask)
    {
        if (animator != null)
        {
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
        // QuestTime 시간 동안 대기
        // 시간 지나면 isMissionTriggered를 false로 전환, BackToIdle() 함수 호출

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
