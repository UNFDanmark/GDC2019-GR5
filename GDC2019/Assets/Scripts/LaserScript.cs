using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public GameObject Player;
    public GameObject Hook;
    Vector3 dir;
    Vector3 normDir;
    Vector3 Ground = new Vector3(1f,0f,0f);
    public Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hook.GetComponent<HookScript>().Fired == false)
        {
            dir = Hook.transform.position - Player.transform.position;
            normDir = dir.normalized;
        }


        print("Lazer: " + normDir);

        LaserPosition();
        LaserAngle();

        if(Hook.GetComponent<HookScript>().Fired == true)
        {
            rend.enabled = false;
        }
        else
        {
            rend.enabled = true;
        }
    }

    //
    void LaserPosition()
    {   
            transform.position = (normDir * 5f) + Player.transform.position;

    }

    void LaserAngle()
    {
        if(transform.position.y <= Player.transform.position.y)
        {
            float angle = Vector3.Angle(normDir, Ground);
            transform.eulerAngles = new Vector3(0f, 0f, -angle + 90f);
 
        }
        else
        {
            float angle = Vector3.Angle(normDir, Ground);
            transform.eulerAngles = new Vector3(0f, 0f, angle + 90f);

        }
        


    }
}
