using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _velocity = 50f;
    // _enemyID  0=Enemy1   1=Enemy2    
    [SerializeField] private int _enemyID = default;
    private Transform _player;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _player.position - transform.position;
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
    }

    private void DestructionEnemy()
    {
        Destroy(gameObject);
    }
}
