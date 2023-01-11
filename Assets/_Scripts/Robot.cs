using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private float speed = 2f;

    private float waitTime = 1f;
    private float waitCounter = 0f;
    private bool waiting = false;

    private void Update()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter < waitTime)
            {
                return;
            }

            waiting = false;
        }

        Transform wp = waypoints[currentWaypointIndex];
        if (Vector3.Distance(transform.position, wp.position) < 0.01f)
        {
            transform.position = wp.position;
            waitCounter = 0f;
            waiting = true;

            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);
            transform.LookAt(wp.position);
        }
    }
}
