using System.Collections;
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
    }

    public void WinnerText()
    {
        if(_mainTokenScript.isMultiplayer == true)
        {
            if (_multiplayerScoreScript.GetWinner() == "left") scoreText.text = "Left Player Won!";
            else if (_multiplayerScoreScript.GetWinner() == "right") scoreText.text = "Right Player Won!";
            else scoreText.text = "Draw!";
        }
        else
        {
            Debug.Log("I'm in single player mode");
            // code here
        }
        
    }

    void Start()
    {
        _mainTokenScript = (MainToken)FindFirstObjectByType(typeof(MainToken));
        _multiplayerScoreScript = (MultiplayerScore)FindFirstObjectByType(typeof(MultiplayerScore));
    }

}
