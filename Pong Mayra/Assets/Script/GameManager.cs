using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    // Game objects for UI Elements
    public TextMeshProUGUI player1ScoreText; // Text Object for Player 1 Score, set in inspector
    public TextMeshProUGUI player2ScoreText; // Text Object for Player 2 Score, set in inspector

    // Scores
    private int player1Score = 0; // Player 1 Score
    private int player2Score = 0; // Player 2 Score

    // Start is called before the first frame update
    void Start()
    {
        // Add error handling for null TextMeshProUGUI components
        if (player1ScoreText == null || player2ScoreText == null)
        {
            Debug.LogError("TextMeshProUGUI components not assigned in GameManager.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update the player scores
        if (player1ScoreText != null && player2ScoreText != null)
        {
            player1ScoreText.text = "P1: " + player1Score;
            player2ScoreText.text = "P2: " + player2Score;
        }
    }

    // When Player 1 Scores, run this function
    public void Player1Scored()
    {
        player1Score++; // Add 1 to score value
    }

    // When Player 2 Scores, run this function
    public void Player2Scored()
    {
        player2Score++; // Add 1 to score value
    }
}
