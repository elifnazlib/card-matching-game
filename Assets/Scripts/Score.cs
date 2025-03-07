using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int score = 0; // Total score of the player
    [SerializeField] private TextMeshProUGUI scoreText; // TextMeshProUGUI instance to show the score on the screen

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = score.ToString(); // Updating the score text on the screen
    }

    public int GetScore()
    {
        return score;
    }
}
