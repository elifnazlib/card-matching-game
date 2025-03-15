using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
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
        BGMusic bgMusic = FindObjectOfType<BGMusic>();
        if (bgMusic != null)
        {
            bgMusic.ChangeMusic("Multiplayer");
        }
    }

    public void ChillPlayClicked() {
        SceneManager.LoadSceneAsync("ChillMode", LoadSceneMode.Single);
        BGMusic bgMusic = FindObjectOfType<BGMusic>();
        if (bgMusic != null)
        {
            bgMusic.ChangeMusic("ChillMode");
        }
    }

    public void PlayAgainstTimeModeClicked() {
        mainMenuPanel.SetActive(false);
        playAgainstTimeMenuPanel.SetActive(true);
        singlePlayerMenuPanel.SetActive(false);
    }

    public void GoBackToMainMenu() {
        mainMenuPanel.SetActive(true);
        playAgainstTimeMenuPanel.SetActive(false);
        singlePlayerMenuPanel.SetActive(false);
    }

    public void EasyModeClicked() {
        SceneManager.LoadSceneAsync("EasyMode", LoadSceneMode.Single);
        BGMusic bgMusic = FindObjectOfType<BGMusic>();
        if (bgMusic != null)
        {
            bgMusic.ChangeMusic("EasyMode");
        }
    }

    public void MediumModeClicked() {
        SceneManager.LoadSceneAsync("MediumMode", LoadSceneMode.Single);
        BGMusic bgMusic = FindObjectOfType<BGMusic>();
        if (bgMusic != null)
        {
            bgMusic.ChangeMusic("MediumMode");
        }
    }

    public void HardModeClicked() {
        SceneManager.LoadSceneAsync("HardMode", LoadSceneMode.Single);
        BGMusic bgMusic = FindObjectOfType<BGMusic>();
        if (bgMusic != null)
        {
            bgMusic.ChangeMusic("HardMode");
        }
    }

    public void GoBackToSinglePlayerMenu() {
        mainMenuPanel.SetActive(false);
        playAgainstTimeMenuPanel.SetActive(false);
        singlePlayerMenuPanel.SetActive(true);
    }

}
