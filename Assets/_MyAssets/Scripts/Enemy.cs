using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _velocity = 50f;
    // _enemyID  0=Enemy1   1=Enemy2    
    [SerializeField] private int _enemyID = default;
    [SerializeField] private GameObject _eliminationPrefab = default;
    private Rigidbody2D _rb;
    private Player _player;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _player.transform.position - transform.position;
        direction.Normalize();
        _rb.velocity = direction * Time.fixedDeltaTime * _velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Balle")
        {

            Destroy(collision.gameObject);
            DestructionEnemy();

        }
        if (collision.tag == "Player")
        {
            _player.Damage();
            DestructionEnemy();

        }
    }



    private void DestructionEnemy()
    {
        Instantiate(_eliminationPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
        spawnManager.SpawnPU(this.gameObject);
    }
       
}
