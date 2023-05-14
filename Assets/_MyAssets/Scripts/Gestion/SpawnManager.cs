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
    [SerializeField] private float _vitesseSpawn = 1.5f;

    Enemy _enemy;
    private float _SpawnPU = 10f;
    private float _dificulte= 10f;
    private float _nombreKill = 0;
    private bool _ajoutVie = false;

    public bool AjoutVie { get => _ajoutVie; set => _ajoutVie = value; }

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
        if (_vitesseSpawn > 1.1f)
        {
            if (_nombreKill >= _dificulte)
            {
                _dificulte += 10f;
                _vitesseSpawn -= 0.05f;
            }
        }
        else
        {
            if (_nombreKill >= _dificulte)
            {
                _dificulte += 30f;
                _ajoutVie = true;
            }
        }
    }

    public void SpawnPU(GameObject enemy)
    {
        if (Time.time > _SpawnPU)
        {
            _SpawnPU = Time.time + Random.Range(8f, 15f);
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
