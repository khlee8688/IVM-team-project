using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private static InteractionManager instance;
    public static InteractionManager Instance => instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    // public void Interact(GameObject target, int questType)
    // {
    //     var interactable = target.GetComponent<IInteractable>();
    //     if (interactable != null)
    //     {
    //         interactable.OnInteract(questType);
    //     }
    // }
    public void Interact(GameObject obj, int questType)
    {
        // 최상위 부모 오브젝트를 찾음
        GameObject rootObj = obj.transform.root.gameObject;

        // IInteractable을 구현한 컴포넌트를 검색
        IInteractable interactable = rootObj.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.OnInteract(questType);
        }
        else
        {
            Debug.LogWarning($"Selected NPC {rootObj.name} does not implement IInteractable.");
        }
    }

    public void Interact(GameObject target)
    {
        // 최상위 부모 오브젝트를 찾음
        GameObject rootObj = target.transform.root.gameObject;

        // IInteractable을 구현한 컴포넌트를 검색
        IInteractable interactable = rootObj.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.OnInteract();
        }
        else
        {
            // 하위 오브젝트에서 IInteractable을 검색
            IInteractable[] interactables = target.GetComponentsInChildren<IInteractable>();
            if (interactables.Length > 0)
            {
                foreach (IInteractable childInteractable in interactables)
                {
                    childInteractable.OnInteract();
                }
            }
            else
            {
                Debug.LogWarning($"Selected NPC {rootObj.name} and its children do not implement IInteractable.");
            }
        }
    }
}
