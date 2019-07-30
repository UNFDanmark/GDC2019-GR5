using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookSoundScript : MonoBehaviour
{

    bool IsPlaying;
    public AudioClip SnorLyd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool IsItHit = GetComponent<HookScript>().Hooked;
        bool HookMoving = GetComponent<HookScript>().Fired;
        
        if (!IsItHit)
        {
            IsPlaying = false;
        }

        if (IsItHit == true && IsPlaying == false)
        {
            PlayHookAttachSound();
            IsPlaying = true;
        }

    }

    void PlayHookAttachSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    //void PlayHookShootSound()
    //{
    //    gameObject.GetComponent<AudioSource>().PlayOneShot();
    //}
}
