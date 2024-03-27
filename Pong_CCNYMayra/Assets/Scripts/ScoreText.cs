using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    // used to display score ingame
    public TextMeshProUGUI text;
// update scores and take integar "value": which is the new score to display when scored on
    public void SetScore(int value)
    {
        // updates the text in the game ui so its visible 
        text.text = value.ToString();
    }
}
