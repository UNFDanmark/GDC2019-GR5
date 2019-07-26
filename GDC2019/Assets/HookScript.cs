using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    public Rigidbody rb;
    public float HookSpeed = 100f;
    public float PullForce = 10f;
    Rigidbody ColRig;
    public GameObject Player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }


    void Update()
    {
        HookShot();
        
    }

 
    void OnCollisionEnter(Collision col)
    {
       

        if (col.gameObject.CompareTag("Drag"))
        {
            col.gameObject.transform.parent = gameObject.transform;
            ColRig = col.gameObject.GetComponent<Rigidbody>();
            ColRig.isKinematic = true;

            Vector3 DragWay;
            float xpos = gameObject.transform.position.x;
            float ypos = gameObject.transform.position.y;
            float PlayerXPos = Player.transform.position.x;
            float PlayerYPos = Player.transform.position.y;

            DragWay = new Vector3((PlayerXPos - xpos)/Mathf.Sqrt((PlayerXPos - xpos) * (PlayerXPos - xpos) + (PlayerYPos - ypos) * (PlayerYPos - ypos)), 
                                  (PlayerYPos - ypos)/Mathf.Sqrt((PlayerXPos - xpos) * (PlayerXPos - xpos) + (PlayerYPos - ypos) * (PlayerYPos - ypos)));
            rb.AddForce(DragWay * PullForce);



        }

        if (col.gameObject.CompareTag("UnDrag"))
        {
            
        }

        /*
        if (col.gameObject.CompareTag("Player"))
        {
            ColRig.isKinematic = false; 
        }
        */
    }

    //Skyde Hook
    void HookShot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.isKinematic = false;
            rb.AddForce(Vector3.right * HookSpeed);
        }
    }
}
