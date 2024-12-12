using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shim_MenuButton : MonoBehaviour, IInteractable
{
    [SerializeField] int mainMenuBuildId = 0; //후에 맵들 완성되면 build > Scenes in Build에 추가 후 수정

    public void OnInteract(int QuestType)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract()
    {
        Debug.Log("Shim_MenuButton, OnInteract() function called");
        ToMainMenu();
    }

    public void ToMainMenu()
    {
        Debug.Log("Shim_MenuButton, ToMainMenu() function called");
        SceneManager.LoadScene(mainMenuBuildId);
    }
}
