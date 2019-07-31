using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSKærmScript : MonoBehaviour
{
    bool isShow = false;
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
        if(isShow == false)
        {
            Tavle.SetActive(true);
            BLur.SetActive(true);
            isShow = true;
            return;
        }

        if (isShow == true)
        {
            Tavle.SetActive(false);
            BLur.SetActive(false);
            isShow = false;
        }

    }
}
