using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseUI;

    private bool paused = false;

    void Start()
    {
        pauseUI.SetActive(false);

    }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;

        }

        if(paused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(!paused)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void Resume()
    {
		paused = !paused;
    }

    public void mainMenu()
    {

    }

    public void Quit()
    {	
		Debug.Log ("TETETETET");
        Application.Quit();
    }

}
