using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookSoundScript : MonoBehaviour
{

    bool IsPlaying;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool IsItHit = gameObject.GetComponent<HookScript>().Hooked; 
        bool HookMoving = 
        
        if (!IsItHit)
        {
            IsPlaying = false;
        }

        if (IsItHit == true && IsPlaying == false)
        {
            PlaySound();
            IsPlaying = true;
        }

    }

    void PlaySound()
        {
        gameObject.GetComponent<AudioSource>().Play();
        }
}
