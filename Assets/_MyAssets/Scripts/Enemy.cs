using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _velocity = 50f;
    // _enemyID  0=Enemy1   1=Enemy2    
    [SerializeField] private int _enemyID = default;
    [SerializeField] private int _vie = 1;
    [SerializeField] private GameObject _eliminationPrefab = default;
    [SerializeField] private GameObject _enemyBalle= default;
    private Rigidbody2D _rb;
    private Player _player;
    private GameManager _gestionJeu;
    private float _fireRate;
    private float _canFire;

    void Start()
    {
        _gestionJeu = FindObjectOfType<GameManager>();
        _rb = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<Player>();
        _canFire = Random.Range(0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _player.transform.position - transform.position;
        direction.Normalize();
        _rb.velocity = direction * Time.fixedDeltaTime * _velocity;
        TirEnnemi();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Balle")
        {

            Destroy(collision.gameObject);
            if (_vie <= 0)
            {
                DestructionEnemy();
                switch(_enemyID)
                {
                    case 0:{ _gestionJeu.AugmenterPointage(10); } break;
                    case 1:{ _gestionJeu.AugmenterPointage(20); } break;
                    case 2:{ _gestionJeu.AugmenterPointage(30); } break;

                }

            }
            else
            {
                _vie--;
            }


        }
        if (collision.tag == "Player")
        {
            _player.Damage();
            DestructionEnemy();

        }
    }

    private void TirEnnemi()
    {
        if (_gestionJeu.Pointage > 100)
        {
            if (Time.time > _canFire)
            {
                _fireRate = Random.Range(1f, 3f);
                _canFire = Time.time + _fireRate;
                Instantiate(_enemyBalle, transform.position, Quaternion.identity);
            }
        }
    }

    private void DestructionEnemy()
    {
        Instantiate(_eliminationPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
        spawnManager.SpawnPU(this.gameObject);
        spawnManager.Kill();
    }
}
