using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    [SerializeField] private Vector3[] _listPositonSpawn = default;
    [SerializeField] private GameObject[] _listPrefabEnemy = default;
    [SerializeField] private GameObject _enemyContainer = default;
    [SerializeField] private GameObject[] _listPowerUp = default;
    [SerializeField] private bool _stopSpawn = false;
    [SerializeField] private float _vitesseSpawn = 2f;

    Enemy _enemy;
    private float _SpawnPU = 10f;
    private float _SpawnRate= 10f;
    private float _nombreKill = 0;

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
            AugmenterVitesseSpawn();
            Vector3 posSpawn = _listPositonSpawn[Random.Range(0, _listPositonSpawn.Length)];
            GameObject newEnemy = Instantiate(_listPrefabEnemy[Random.Range(0, _listPrefabEnemy.Length)], posSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_vitesseSpawn);
        }

    }

    private void AugmenterVitesseSpawn()
    {
        if (_vitesseSpawn > 0.6f)
        {
            if (_nombreKill >= _SpawnRate)
            {
                _SpawnRate += 5f;
                _vitesseSpawn -= 0.2f;
            }
        }
    }

    public void SpawnPU(GameObject enemy)
    {
        if (Time.time > _SpawnPU)
        {
            _SpawnPU = Time.time + 10f;
            Instantiate(_listPowerUp[Random.Range(0, _listPowerUp.Length)], enemy.transform.position, Quaternion.identity);
        }
    }

    public void FinPartie()
    {
        _stopSpawn = true;
    }

    public void Kill()
    {
        _nombreKill++;
    }
}
