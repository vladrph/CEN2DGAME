//This is code based on the video 2D Zombie AI in Unity - State Machine Behaviors
//Specific Purpose: Used to control Zombie's frontward and backward movement based on the scale of object.

using UnityEngine;

public class Zombie : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(0.45f, 0.45f);
        }
        
    }
}


