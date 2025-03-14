using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// This script is used to control the timer. (https://discussions.unity.com/t/simple-timer/56201)
public class Timer : MonoBehaviour
{
    [SerializeField] private float targetTime = 5.0f; // Target time for the timer
    [SerializeField] private TextMeshProUGUI timerText; // TextMeshProUGUI instance to show the timer on the screen
    private bool isTimerEnded = false; // Is used to check if the timer is ended
    public bool isGameEndedBeforeTimer = false;
    private GameOver _gameOverScript;
    string sceneName;
    private int count = 0;

    void Start()
    {
        _gameOverScript = (GameOver)FindFirstObjectByType(typeof(GameOver));
        sceneName = SceneManager.GetActiveScene().name;
    }
    
    void Update()
    {   
        if(sceneName == "ChillMode" &&  isGameEndedBeforeTimer == false)
        {
            targetTime += Time.deltaTime; 
            // timerText.text = TimeSpan.FromSeconds(targetTime).ToString(@"ss");
            timerText.text = ((int) targetTime).ToString();
        }
        else if (!isTimerEnded && isGameEndedBeforeTimer == false) // If the timer is not ended
        {
            targetTime -= Time.deltaTime; // Decrease the target time by the time passed since the last frame
            // timerText.text = TimeSpan.FromSeconds(targetTime).ToString(@"mm\:ss"); // Update the timer text on the screen
            timerText.text = TimeSpan.FromSeconds(targetTime).ToString(@"ss"); // Update the timer text on the screen
        }

        if (sceneName != "ChillMode" && targetTime <= 0.0f) // If the target time is less than or equal to 0
        {
            isTimerEnded = true; // Set the timer as ended
            if(count == 0)
            {
                count = 1;
                _gameOverScript.ActivateGameOverPanel();
            }
            
        }
    }

    public bool IsTimerEnded()
    {
        return isTimerEnded;
    }

    public int GetRemainingTime()
    {
        return (int) targetTime;
    }

    public void ChangeState(bool state)
    {
        isGameEndedBeforeTimer = state;
    }

    

}