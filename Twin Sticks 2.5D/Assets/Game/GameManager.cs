using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording;
    public bool paused = false;
    public GameObject Pause;

    private float fixedDeltaTime;
    private GameObject player;

    // Use this for initialization
    void Start() {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update() {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        Pause.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = fixedDeltaTime;
        Pause.SetActive(false);

    }

    void Exit()
    {
        Application.Quit();
    }
}
