using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public float KonamiTime = 20f;
    float TimeLeft = 0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void Konami()
    {

        TimeLeft = TimeLeft - 0.02f * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TimeLeft = 20;

        }
        
        
        

    }



}

