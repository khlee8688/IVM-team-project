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

    public void Interact(GameObject target, int questType)
    {
        var interactable = target.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.OnInteract(questType);
        }
    }

    public void Interact(GameObject target)
    {
        var interactable = target.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.OnInteract();
        }
    }
}
