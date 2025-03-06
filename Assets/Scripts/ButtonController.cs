using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject singlePlayerMenuPanel;
    [SerializeField] GameObject playAgainstTimeMenuPanel;

    public void SinglePlayerModeClicked() {
        mainMenuPanel.SetActive(false);
        playAgainstTimeMenuPanel.SetActive(false);
        singlePlayerMenuPanel.SetActive(true);
    }

    public void MultiplayerModeClicked() {
        SceneManager.LoadSceneAsync("Multiplayer", LoadSceneMode.Single);
    }

    public void ChillPlayClicked() {
        SceneManager.LoadSceneAsync("ChillMode", LoadSceneMode.Single);
    }

    public void PlayAgainstTimeModeClicked() {
        mainMenuPanel.SetActive(false);
        playAgainstTimeMenuPanel.SetActive(true);
        singlePlayerMenuPanel.SetActive(false);
    }

    public void EasyModeClicked() {
        SceneManager.LoadSceneAsync("EasyMode", LoadSceneMode.Single);
    }

    public void MediumModeClicked() {
        SceneManager.LoadSceneAsync("MediumMode", LoadSceneMode.Single);
    }

    public void HardModeClicked() {
        SceneManager.LoadSceneAsync("HardMode", LoadSceneMode.Single);
    }

}
