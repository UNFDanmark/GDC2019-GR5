using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSKærmScript : MonoBehaviour
{

    public GameObject Tavle;
    public GameObject BLur;
    // Start is called before the first frame update
    void Start()
    {
        Tavle.SetActive(false);
        BLur.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
    }

    public void Cont()
    {
        Tavle.SetActive(true);
        BLur.SetActive(true);
    }
}
