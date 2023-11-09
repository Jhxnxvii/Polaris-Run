using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour

// A variable to keep track of the collected hearts.
{
    private int hearts = 0;

    [SerializeField] private TextMeshProUGUI heartsText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)

    // Check if the colliding object has a tag "Heart".
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            hearts++;
            heartsText.text = "Hearts: " + hearts;
        }
    }
}

