using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Hook;
    public Material TargetOff;
    public Material TargetOn;
    Vector3 dir;
    Vector3 normDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 10;

        if (Hook.GetComponent<HookScript>().Fired == false)
        {
            gameObject.GetComponent<Renderer>().material = TargetOff;
            dir = Hook.transform.position - Player.transform.position;
            normDir = dir.normalized;
            RaycastHit hit;

            if (Physics.Raycast(Player.transform.position, normDir, out hit, Mathf.Infinity, layerMask))
            {
                transform.position = hit.point;

            }
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = TargetOn;
        }
    }




}
