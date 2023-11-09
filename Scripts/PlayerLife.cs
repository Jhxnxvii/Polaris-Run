using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()

    // Get references to the Rigidbody2D and Animator components from this game object.
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    // Custom method to handle the character's death.
    private void Die()
    {
        deathSoundEffect.Play();

        // Set the Rigidbody2D to Static to stop movement.
        rb.bodyType = RigidbodyType2D.Static;

        // Trigger a death animation in the Animator.
        anim.SetTrigger("death");
    }

    // Custom method to restart the level by reloading the current scene.
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
