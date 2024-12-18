using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Animator animator;
    private bool isAsking = false;
    // Start is called before the first frame update
    void Start()
    {
        // animator = GetComponent<Animator>();

        // if (animator == null)
        // {
        //     Debug.LogError("Animator component not found on the GameObject.");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // 'A' 키 입력 확인
        if (Input.GetKeyDown(KeyCode.A) && !isAsking)
        {
            StartCoroutine(TriggerAskingMotion());
        }
    }

    // 질문 모션을 트리거하는 코루틴
    private IEnumerator TriggerAskingMotion()
    {
        isAsking = true;

        // Animator의 파라미터 값을 변경하여 질문 모션 시작
        animator.SetBool("isAsking", true);
        animator.SetBool("isIdle", false);

        // 5초 대기
        yield return new WaitForSeconds(5f);

        // Animator의 파라미터 값을 변경하여 원래 모션으로 복귀
        animator.SetBool("isAsking", false);
        animator.SetBool("isIdle", true);

        isAsking = false;
    }
}
