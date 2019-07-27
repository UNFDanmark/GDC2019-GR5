using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    bool Hooked = false;
    bool Fired = false;
    int DragAble = 0;

    public float HookSpeed = 100f;
    public float PullForce = 10f;
    public float DragForce;
    public float AimSpeed;
    public GameObject Player;
    public GameObject Target;
    //Vector3 PlayerPos = new Vector3(Player.transform.position.x, Player.transform.position.y, 0);
    Vector3 PlayerPos = new Vector3(0, 0, 0);
    

    void Start()
    {
        Physics.IgnoreLayerCollision(8, 9);
        Physics.IgnoreLayerCollision(8, 10);
    }


    void Update()
    {
        PushOutOfBox();
        Aim();
        HookShot();
        Release();

        Vector3 AimDir = transform.position - Player.transform.position;
        Vector3 AimNormDir = AimDir.normalized;

        //sender hooken afsted
        if (Fired && !Hooked)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().AddForce(AimDir * HookSpeed);
        }

        //trækker hooken tilbage
        if (Fired && Hooked && DragAble == 1)
        {
            float step = DragForce * Time.deltaTime;

            Vector3 dir = Player.transform.position - transform.position;
            Vector3 NormDir = dir.normalized;
            GetComponent<Rigidbody>().AddForce(NormDir * step);

            print(NormDir);
 
        }
        
        //Trækker player til hook
        if (Fired && Hooked && DragAble == 2)
        {
            float step = PullForce * Time.deltaTime;

            Vector3 dir = transform.position - Player.transform.position;
            Vector3 NormDir = dir.normalized;
            Player.GetComponent<Rigidbody>().AddForce(NormDir * step);
          
            print(-NormDir);
        }
    }

    
    void OnCollisionEnter(Collision col)
    {   
        if(!Hooked && Fired)
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
        if(Hooked && Fired)
        {
            Hooked = false;
            Fired = false;
            DragAble = 0;
            Destroy(Target.GetComponent<CharacterJoint>());
            Destroy(Target.GetComponent<FixedJoint>());
            print(Target.name);
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
        if(!Hooked && !Fired)
        {
            /* if (transform.position.y >= Player.transform.position.y - 0.01)
             {
                 transform.RotateAround(Player.transform.position, Vector3.back, AimSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
             }

             else
             {
                 transform.RotateAround(Player.transform.position, Vector3.back, AimSpeed * -Input.GetAxis("Horizontal") * Time.deltaTime);
             }*/

            transform.RotateAround(Player.transform.position, Vector3.back, AimSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }
        

    }

    float ChekPos()
    {
        Vector3 PlayerHookDis = transform.position - Player.transform.position;
        float temp = PlayerHookDis.magnitude;
        return temp;
    }

    void PushOutOfBox()
    {
        if (ChekPos() < 0.5f)
        {
            /*Vector3 dir = transform.position - Player.transform.position;
            Vector3 NormDir = dir.normalized;
            transform.position = NormDir * 2f;*/
            transform.localPosition = new Vector3(0f, 0f, 0.5f);

        }
    }

  

    void Release()
    {
        if(Hooked && Fired && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(Target.GetComponent<CharacterJoint>());
            Destroy(Target.GetComponent<FixedJoint>());
        }
    }
}
