using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Collector class handles collecting items when the player collides with them
public class Collector : MonoBehaviour
{
    // Triggered when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision.GetComponent<IItem>(); // Check if the collided object implements IItem
        if(item != null) 
        {
            item.Collect(); // Call the Collect method on the item
        }
    }
}
