//Enemy Spawner Script: Derived from Stack Overflow and changed for Zombie2D sprite
//General Purpose: Spawns an enemy every 10 seconds 
using System.Collections;
using Systems.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    public GameObject Zombie2D;
    
    [SerializeField]private float interval = 10f;
    private float timer = 0f;
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= interval) {
            timer = 0f;
            Instantiate(Zombie2D, transform.position, transform.rotation);
        }
    }
}
