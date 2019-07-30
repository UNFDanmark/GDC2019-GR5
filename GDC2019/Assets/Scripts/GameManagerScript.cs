using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    bool GameIsPaused = false;
    public GameObject ExitToStart;
    public GameObject ExitGameBTN;
    public GameObject Blur;


    // Start is called before the first frame update
    void Start()
    {
        ExitToStart.SetActive(false);
        ExitGameBTN.SetActive(false);
        Blur.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pause();


    }

    void pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == false)
            {
                Time.timeScale = 0;
                GameIsPaused = true;
                ExitToStart.SetActive(true);
                ExitGameBTN.SetActive(true);
                Blur.SetActive(true);
                print("Paused");
            }

            else

            {
                Time.timeScale = 1;
                GameIsPaused = false;
                ExitToStart.SetActive(false);
                ExitGameBTN.SetActive(false);
                Blur.SetActive(false);
            }
        }
    }

    public void ExitToStartScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Game close");
    }


}

