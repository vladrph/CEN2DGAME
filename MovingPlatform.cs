
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> points;
    public Transform platform;
    int goalPoint = 0;
    public float moveSpeed = 2;

    private void Update()
    {
        MoveToNextPoint();
    }
    
    void MoveToNextPoint()
    {
        //change the position of the platform
        platform.position = Vector2.MoveTowards(platform.position, points[goalPoint].position,Time.deltaTime * moveSpeed);
        //check if we are close to the desired waypoint
        if (Vector2.Distance(platform.position, points[goalPoint].position) < 0.1f)
        {
            //if yes, change the goal point to its position
            if (goalPoint == points.Count - 1)
            {
                goalPoint = 0;
            }
            else
            {
                goalPoint++;
            }
        }
    }
}
