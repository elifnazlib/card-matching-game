using TMPro;
using UnityEngine;

public class MultiplayerScore : MonoBehaviour
{
    [SerializeField] private int leftScore = 0;
    [SerializeField] private int rightScore = 0;
    [SerializeField] private TextMeshProUGUI leftScoreText;
    [SerializeField] private TextMeshProUGUI rightScoreText;
    [SerializeField] private ChangePlayer _playerScript;
    

    public void UpdateScore()
    {
        if(_playerScript.GetCurrentPlayer() == "left")
        {
            leftScore += 1;
            leftScoreText.text = leftScore.ToString();
        }
        else if (_playerScript.GetCurrentPlayer() == "right")
        {
            rightScore += 1;
            rightScoreText.text = rightScore.ToString();
        }
    }

    public string GetWinner()
    {
        if (leftScore > rightScore) return "left";
        else if (leftScore < rightScore) return "right";
        else return "draw";
    }
}
