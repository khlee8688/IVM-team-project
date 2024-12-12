using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    public GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TestAnimation is start");
    }

    // Update is called once per frame
    void Update()
    {
        Test();
    }

    void Test()
    {
        bool primaryIndexTrigger = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        bool secondaryTrigger = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.RTouch);

        if (primaryIndexTrigger || secondaryTrigger)
        {
            InteractionManager.Instance.Interact(npc, 1);
        }

    }
}
