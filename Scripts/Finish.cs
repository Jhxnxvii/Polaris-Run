using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    // Flag to track if the level has been completed and getting the AudioSource component from the same game object.
    private bool levelCompleted = false;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)

    // Check if the collision involves an object named "Player" and the level is not already completed.
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;

            // Delay for 2 seconds before calling the "CompleteLevel" method.
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()

    // Load the next scene based on the current scene's build index.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
