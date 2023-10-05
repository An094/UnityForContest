using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRate;
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
            yield return wait;
            GameObject enemy = ObjectPooler.Instance.SpawnFromPool("Enemy", Vector2.zero, Quaternion.identity);
            enemy.SetActive(true);
        }

    }
}
