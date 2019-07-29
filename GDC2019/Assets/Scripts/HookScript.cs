using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{

    public bool Hooked = false;
    public bool Fired = false;
    bool released = false;
    bool jointKilled = false;
    int DragAble = 0;
    Vector3 AimDir;
    Vector3 AimNormDir;
    public float HookSpeed = 100f;
    public float PullForce = 10f;
    public float DragForce;
    public float AimSpeed;
    public float HookReturnForce;
    public GameObject Player;
    public GameObject Target;
    //Vector3 PlayerPos = new Vector3(Player.transform.position.x, Player.transform.position.y, 0);
    Vector3 PlayerPos = new Vector3(0, 0, 0);


    void Start()
    {
        Physics.IgnoreLayerCollision(8, 9);
        //Physics.IgnoreLayerCollision(8, 10);
    }


    void FixedUpdate()
    {
        print("test" + transform.localEulerAngles);
        //PushOutOfBox();
        Aim();
        if((transform.localEulerAngles.z<140 && transform.localEulerAngles.z > 35) == false)
        {
            HookShot();

        }

        Release();
        ReleasePart2();
        restart();


        if (!Fired)
        {
            AimDir = transform.position - Player.transform.position;
            AimNormDir = AimDir.normalized;


        }


        //sender hooken afsted
        if (Fired && !Hooked)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().AddForce(AimNormDir * HookSpeed);

        }

        //trækker hooken tilbage
        if (Fired && Hooked && DragAble == 1)
        {
            float step = DragForce * Time.deltaTime;

            Vector3 dir = Player.transform.position - transform.position;
            Vector3 NormDir = dir.normalized;
            GetComponent<Rigidbody>().AddForce(NormDir * step);



        }

        //Trækker player til hook
        if (Fired && Hooked && DragAble == 2 && released == false)
        {
            float step = PullForce * Time.deltaTime;

            Vector3 dir = transform.position - Player.transform.position;
            Vector3 NormDir = dir.normalized;
            Player.GetComponent<Rigidbody>().AddForce(NormDir * step);



        }


    }


    void OnCollisionEnter(Collision col)
    {
        if (!Hooked && Fired)
        {
            Target = col.gameObject;


            //sætter hooken på kassen, og annulere fart/moment
            if (Target.CompareTag("Drag") && Fired)
            {
                Hooked = true;
                DragAble = 1;

                Target.AddComponent<CharacterJoint>();
                Target.GetComponent<CharacterJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                Target.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

            if (Target.CompareTag("UnDrag") && Fired)
            {
                Hooked = true;
                DragAble = 2;
                Target.AddComponent<FixedJoint>();
                Target.GetComponent<FixedJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

    }

    private void OnTriggerEnter(Collider trig)
    {
        //slipper kassen og resetter hooken
        if (Hooked && Fired)
        {
            released = false;
            jointKilled = false;
            Hooked = false;
            Fired = false;
            DragAble = 0;
            transform.localPosition = new Vector3(0f, 0.5f, 0f);
            transform.localEulerAngles = new Vector3(0f, 90f, -90f);
            Destroy(Target.GetComponent<CharacterJoint>());
            Destroy(Target.GetComponent<FixedJoint>());
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

        }

    }

    //Skyde Hook
    void HookShot()
    {
        //input for at skyde hooken afsted
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fired = true;
        }
    }

    //drej hook om player
    void Aim()
    {
        if (!Hooked && !Fired)
        {
            /* if (transform.position.y >= Player.transform.position.y - 0.01)
             {
                 transform.RotateAround(Player.transform.position, Vector3.back, AimSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
             }

             else
             {
                 transform.RotateAround(Player.transform.position, Vector3.back, AimSpeed * -Input.GetAxis("Horizontal") * Time.deltaTime);
             }*/
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.RotateAround(Player.transform.position, Vector3.back, AimSpeed * -1 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.RotateAround(Player.transform.position, Vector3.back, AimSpeed * 1 * Time.deltaTime);
            }

        }


    }

    /*
    float ChekPos()
    {
        Vector3 PlayerHookDis = transform.position - Player.transform.position;
        float temp = PlayerHookDis.magnitude;
        return temp;
    }

    void PushOutOfBox()
    {
        if (ChekPos() < 0.4f)
        {
            Vector3 dir = transform.position - Player.transform.position;
            Vector3 NormDir = dir.normalized;
            transform.localPosition = NormDir * 0.5f;


        }
    } */


    void restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }


    //Retunere hook
    void ReleasePart2()
    {
        if (DragAble == 2 && jointKilled)
        {
            float step = HookReturnForce * Time.deltaTime;
            released = true;
            Vector3 dir = Player.transform.position - transform.position;
            Vector3 NormDir = dir.normalized;
            GetComponent<Rigidbody>().AddForce(NormDir * step);

        }
    }

    //Sletter Joints
    void Release()
    {
        if(Hooked && Fired && Input.GetKeyDown(KeyCode.Space))
        {

            Destroy(Target.GetComponent<CharacterJoint>());
            Destroy(Target.GetComponent<FixedJoint>());

            jointKilled = true;

           
        }

       
        
    }
}
