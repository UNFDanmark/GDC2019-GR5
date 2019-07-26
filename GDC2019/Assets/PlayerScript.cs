using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Hook;
    public float HookSpeed = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject instHook = Instantiate(Hook, transform.position, Quaternion.identity);
            Rigidbody instHookRigidbody = instHook.GetComponent<Rigidbody>();
            instHookRigidbody.AddForce(Vector3.right * HookSpeed);

        }
    }


}
