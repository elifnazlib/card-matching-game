using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI scoreText;
    private MultiplayerScore _multiplayerScoreScript;
    private MainToken _mainTokenScript;
    private Timer _timerScript;
    private Score _scoreScript;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip loseSound;

    void Start()
    {
        _mainTokenScript = (MainToken)FindFirstObjectByType(typeof(MainToken));
        
        if(_mainTokenScript.isMultiplayer == false)
        {
            _timerScript = (Timer)FindFirstObjectByType(typeof(Timer));
            _scoreScript = (Score)FindFirstObjectByType(typeof(Score));
        }
        else
        {
            _multiplayerScoreScript = (MultiplayerScore)FindFirstObjectByType(typeof(MultiplayerScore));
        }
    }

    public void ActivateGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        WinnerText();
    }

    public void ResetVariables()
    {
        MainToken.faceIndexes = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7};
        GameControl.visibleFaces[0] = -1;
        GameControl.visibleFaces[1] = -2;
    }

    public void RestartButtonClicked()
    {
        ResetVariables();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(currentSceneName, LoadSceneMode.Single);
    }

    public void MainMenuButtonClicked()
    {
        ResetVariables();
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        BGMusic bgMusic = FindObjectOfType<BGMusic>();
        if (bgMusic != null)
        {
            bgMusic.ChangeMusic("MainMenu");
        }
    }

    public void WinnerText()
    {
        if(_mainTokenScript.isMultiplayer == true)
        {
            audioSource.PlayOneShot(winSound);
            if (_multiplayerScoreScript.GetWinner() == "left") scoreText.text = "Left Player Won!";
            else if (_multiplayerScoreScript.GetWinner() == "right") scoreText.text = "Right Player Won!";
            else scoreText.text = "Draw!";
        }
        else
        {
            if(SceneManager.GetActiveScene().name == "ChillMode")
            {
                audioSource.PlayOneShot(winSound);
                scoreText.text = "You Finished in " + _timerScript.GetRemainingTime().ToString() + " Seconds";
            }
            else if(_timerScript.IsTimerEnded() == false)
            {
                audioSource.PlayOneShot(winSound);
                scoreText.text = "Your Score with Remaining Time Added is " 
                                + (_scoreScript.GetScore() + _timerScript.GetRemainingTime()).ToString();
            }
            else
            {
                audioSource.PlayOneShot(loseSound);
                scoreText.text = "You Couldn't Finish On Time!";
            }
        }
        
    }

}
