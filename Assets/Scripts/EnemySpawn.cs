using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] enemyReference;

    private GameObject spawnedMonster;

    [SerializeField] 
    private Transform leftPos,rightPos;
    //[SerializeField] 
    //private Transform ;

    private int randomIndex;
    private int randomSide;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());

    }

    // Update is called once per frame
   

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, enemyReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(enemyReference[randomIndex]);

            if (randomSide == 0)
            {
                // left side
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<EnemyMovement>().speed = Random.Range(4, 10);
                // spawnedMonster.G

            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<EnemyMovement>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-2f, 2f, 2f);
            }

        }
    }
}