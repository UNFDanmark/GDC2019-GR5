using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject WinBlock;
    public Material off;
    public Material on;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        WinBlock.GetComponent<Renderer>().enabled = false;
        WinBlock.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Renderer>().material = on;
    }

    private void OnTriggerExit(Collider collision)
    {

        WinBlock.GetComponent<Renderer>().enabled = true;
        WinBlock.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<Renderer>().material = off;

    }


}
