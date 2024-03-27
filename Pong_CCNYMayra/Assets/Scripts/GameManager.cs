using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  // public static instance of gamemanager for it to be accessed globally from other scripts
  public static GameManager instance;
    //stores the scores for player1 and player2
    public int scorePlayer1, scorePlayer2;
    // update score on the UI
    public ScoreText scoreTextLeft, scoreTextRight;
    // resetting specific part of the game when score is made aka paddle and ball
    public System.Action onReset;
    // awake called whn script instance is being loaded
    private void Awake()
    {
      // if another insance exists , its gets garen demacia ult (DESTROY any new one to enforce singleton pattern)
      if (instance)
      {
        Destroy(gameObject);
      }
      else
      {
        // if no instance exists ,makes this as the instance & keeps it alive across scenes 
        instance = this;
      }
    }
    // called when a ball hits scoring zone
    public void OnScoreZoneReached(int id)
    {
      // fowards resets actions
      onReset?.Invoke();
        // increases the score for whoever (player1 & player2) if ball hits score zone
        if (id == 1)
          scorePlayer1++;
        if (id == 2)
          scorePlayer2++;
        // updates the scores to show on the UI
        UpdateScores();
    }
    // updates scores using the ScoreText scripts
    private void UpdateScores()
    {
        scoreTextLeft.SetScore(scorePlayer1);
        scoreTextRight.SetScore(scorePlayer2);
    }
}
