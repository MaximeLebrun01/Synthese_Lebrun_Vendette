using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    [SerializeField] private Vector3[] _listPositonSpawn = default;
    [SerializeField] private GameObject[] _listPrefabEnemy = default;
    [SerializeField] private GameObject _enemyContainer = default;
    [SerializeField] private bool _stopSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());

    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(5f);
        while (!_stopSpawn)
        {
            Vector3 posSpawn = _listPositonSpawn[Random.Range(0, _listPositonSpawn.Length)];
            GameObject newEnemy = Instantiate(_listPrefabEnemy[Random.Range(0, _listPrefabEnemy.Length)], posSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(1f);
        }

    }
}
