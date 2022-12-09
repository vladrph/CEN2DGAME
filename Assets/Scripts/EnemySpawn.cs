using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyReference;

    private GameObject _spawnedMonster;

    [SerializeField] private Transform leftPos, rightPos;

    private int _randomIndex;
    private int _randomSide;

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            _randomIndex = Random.Range(0, enemyReference.Length);
            _randomSide = Random.Range(0, 2);

            _spawnedMonster = Instantiate(enemyReference[_randomIndex]);

            if (_randomSide == 0)
            {
                _spawnedMonster.transform.position = leftPos.position;
                _spawnedMonster.GetComponent<EnemyMovement>().speed = Random.Range(4, 10);
            }
            else
            {
                _spawnedMonster.transform.position = rightPos.position;
                _spawnedMonster.GetComponent<EnemyMovement>().speed = -Random.Range(4, 10);
                _spawnedMonster.transform.localScale = new Vector3(-2f, 2f, 2f);
            }
        }
    }
}