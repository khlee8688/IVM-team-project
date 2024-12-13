using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelector : MonoBehaviour, IInteractable
{
    public int mapLevel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteract(int QuestType)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract()
    {
        switch (mapLevel)
        {
            case 1:
                SceneManager.LoadScene("MeetingRoom");
                break;
            case 2:
                SceneManager.LoadScene("School");
                break;
            case 3:
                SceneManager.LoadScene("University");
                break;
            default:
                SceneManager.LoadScene("MapSelectScene");
                break;
        }
    }
}
