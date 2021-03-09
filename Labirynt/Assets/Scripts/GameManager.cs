using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int timeToEnd;

    bool gamePaused = false;

    bool endGame = false;
    bool win = false;
    // Start is called before the first frame update
    void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    private void Start()
    {
        InvokeRepeating("Stopper", 2, 1);
        if(timeToEnd <= 0)
        {
            timeToEnd = 100;
        }
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + " sekund");

        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
        {
            EndGame(); 
        }
    }

    void PauseGame()
    {
        Debug.Log("Game paused");
        Time.timeScale = 0;
        gamePaused = true;
    }

    void ResumeGame()
    {
        Debug.Log("Game resumed");
        Time.timeScale = 1;
        gamePaused = false;
    }

    void EndGame()
    {
        CancelInvoke("Stopper");
        if(win)
        {
            Debug.Log("You win! Reload?");
        }
        else
            Debug.Log("You lose! Reload?");
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
}
