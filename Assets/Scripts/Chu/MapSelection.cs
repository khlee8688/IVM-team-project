using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            SceneManager.LoadScene("MeetingRoom");
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            SceneManager.LoadScene("University");
        }
        else if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            SceneManager.LoadScene("School");
        }
    }
}
