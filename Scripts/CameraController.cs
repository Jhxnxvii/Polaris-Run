using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
    // This line indicates that we're making a private variable named "player" of type Transform,
    // and we're using the SerializeField attribute to make it visible in the Unity Inspector.
{
    [SerializeField]private Transform player;
  
    private void Update()
    {
        // This line sets the position of the object this script is attached to (the transform)
        // to match the position of the "player" object but keeps the z-coordinate unchanged.
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
