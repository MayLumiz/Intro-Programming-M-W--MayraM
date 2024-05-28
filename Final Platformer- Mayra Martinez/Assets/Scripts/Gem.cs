
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour, IItem 
{
    public static event Action<int> OnGemCollect; // Event for when a gem is collected
    public int worth = 5; // The worth of the gem

    public void Collect() // Collect the gem
    {
        OnGemCollect?.Invoke(worth); 
        Destroy(gameObject); // Destroy the gem
    }
}