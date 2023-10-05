using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRate;

    [SerializeField]
    private GameObject m_player;

    [SerializeField]
    private float spawnRadius = 14.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (true)
        {
            Vector3 randomCircle = Random.insideUnitCircle;

            Vector3 spawnPos = randomCircle * spawnRadius + m_player.transform.position;
            yield return wait;
            GameObject enemy = ObjectPooler.Instance.SpawnFromPool("Enemy", spawnPos, Quaternion.identity);
            enemy.SetActive(true);
        }

    }
}
