using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookSoundScript : MonoBehaviour
{
    bool IsPlayingHitSound;
    bool IsPlayingLeadSound;
    public AudioClip SnorLyd;
    public AudioSource extend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        

        bool IsItHit = GetComponent<HookScript>().Hooked;

        bool HookMoving = GetComponent<HookScript>().Fired;
        //print(isithit);
        if (!IsItHit)
        {
            IsPlayingHitSound = false;
        }

        if (!HookMoving)
        {
            IsPlayingLeadSound = false;
        }

        if (IsItHit)
        {
            extend.Stop();
            print("ye");
        }

        if (IsItHit == true && IsPlayingHitSound == false)
        {
            PlayHookAttachSound();
            IsPlayingHitSound = true;
        }
        
        if (HookMoving == true && IsPlayingLeadSound == false && IsItHit == false)
        {
            PlayHookLeadSound();
            IsPlayingLeadSound = true;
        }
    }
   /* private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<AudioSource>().Play();
    }*/
    void PlayHookAttachSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    void PlayHookLeadSound()
    {
        extend.Play();
        print("boi");
    }
}