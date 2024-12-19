using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundExample : MonoBehaviour
{
    public AudioClip clapSound;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.Instance.PlaySound(clapSound);
        }
    }
}
