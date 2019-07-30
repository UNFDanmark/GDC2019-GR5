using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawKlinge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {

        Physics.IgnoreLayerCollision(10, 12);
    }
 
   

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
