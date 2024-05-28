
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Manages the game state, progress, and UI interactions
public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;
    public GameObject winScreen;
    public Button resetButton;

    // Start is called before the first frame update
    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Gem.OnGemCollect += IncreaseProgressAmount; // Subscribe to gem collection event

        resetButton.onClick.AddListener(ResetGame); // Add listener to reset button
    }

    // Method to increase the progress amount
    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;
        if (progressAmount >= 100) // Check if progress reaches 100
        {
            EndGame();
        }
    }

    // Method to end the game
    void EndGame()
    {
        winScreen.SetActive(true); // Display the win screen

        // Disable player controls
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
            player.enabled = false;
        }
    }

    // Method to reset the game
    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    void Update()
    {
       
    }

    void OnDestroy()
    {
        Gem.OnGemCollect -= IncreaseProgressAmount; // Unsubscribe from gem collection event
    }
}