using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    // An array of waypoints that the object will follow.
    [SerializeField] private GameObject[] waypoints;
    private int currentWayPointIndex = 0;

    // Speed at which the object moves between waypoints.
    [SerializeField] private float speed = 2f;

    // Called once per frame to update the object's movement.
    private void Update()
    {

        // Check if the object is close to the current waypoint.
        if (Vector2.Distance(waypoints[currentWayPointIndex].transform.position, transform.position) < 0.1f)
        {
            // Move to the next waypoint and loop back to the first if at the end.
            currentWayPointIndex++;
            if (currentWayPointIndex >= waypoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }

        // Move the object towards the current waypoint at a specified speed.
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, speed * Time.deltaTime);
    }
}