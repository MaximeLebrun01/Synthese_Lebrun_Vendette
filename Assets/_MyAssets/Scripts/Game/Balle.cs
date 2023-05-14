using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{

    float inputHorizontal;
    float inputVertical;
    Player _player;
    Vector3 _playerPos;
    Vector3 _enemyPos;

    [SerializeField] private float _vitesse = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        inputHorizontal = Input.GetAxis("Fire1");
        inputVertical = Input.GetAxis("Fire2");
        _playerPos = _player.transform.position;
        _enemyPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Balle")
        {
            TirJoueur();
        }
        else if (gameObject.tag == "BalleEnemy")
        {
            TirEnemy();
        }

        DestructionGameObject();
    }



    private void TirEnemy()
    {
        Vector3 direction = _playerPos - _enemyPos;
        direction.Normalize();
        transform.Translate(direction * Time.deltaTime * _vitesse);
    }

    private void TirJoueur()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            transform.Translate(new Vector3(inputHorizontal, inputVertical, 0f) * Time.deltaTime * _vitesse);

        }
    }

    private void DestructionGameObject()
    {
        if (transform.position.x > 4.5f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -4.5f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > 4f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -4f)
        {
            Destroy(gameObject);
        }
    }


}
