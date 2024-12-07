using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] int mainMenuBuildId = 0; //후에 맵들 완성되면 build > Scenes in Build에 추가 후 수정

    public void ToMainMenu()
    {
        SceneManager.LoadScene(mainMenuBuildId);
    }
}
