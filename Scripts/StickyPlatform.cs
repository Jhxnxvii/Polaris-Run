using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is named "Player."
        if (collision.gameObject.name == "Player")
        {
            // Set the "Player" object as a child of this object.
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // Called when a 2D collider exits the trigger area.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Remove the "Player" object from being a child of any object.
            collision.gameObject.transform.SetParent(null);
        }
    }
}