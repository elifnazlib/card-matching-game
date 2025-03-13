using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    [SerializeField] Button exitButton;

    public void ExitGameButtonClicked()
    {
        #if UNITY_STANDALONE
        Application.Quit();
        #endif
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
}
