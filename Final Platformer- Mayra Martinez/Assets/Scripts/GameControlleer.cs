using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        Gem.OnGemCollect += IncreaseProgressAmount;
        
        resetButton.onClick.AddListener(ResetGame);
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;
        if (progressAmount >= 100)
        {
            // You win !!!
            Debug.Log("You Win");
            EndGame();
        }
    }

    void EndGame()
    {
        // Display the win screen
        winScreen.SetActive(true);

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        Gem.OnGemCollect -= IncreaseProgressAmount;
    }
}
