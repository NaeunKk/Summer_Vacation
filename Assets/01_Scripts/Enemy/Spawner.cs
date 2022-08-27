using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPos = new List<Transform>();
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject boss;
    int randIndex = 0;
    int spawnDelay = 1;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    /// <summary>
    /// ���� �Լ�
    /// </summary>
    /// <returns></returns>
    IEnumerator Spawn()
    {
        while (true)
        {
            if (Enemy.enemyCount < 10)
            {
                randIndex = Random.Range(0, spawnPos.Count);
                GameObject temp = PoolManager.Instance.Dequeue(enemyPrefab);
                temp.transform.position = spawnPos[randIndex].position;
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}