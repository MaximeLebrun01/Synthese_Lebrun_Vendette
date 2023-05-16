using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    // _balleID 0=Balle 1=BalleEnemy 2=Random
    [SerializeField] private int _balleID = default;
    [SerializeField] private float _vitesse = 5f;


    private int[] _randomdir = { 0, -1,  1 };
    float inputHorizontal;
    float inputVertical;
    Player _player;
    Vector3 _playerPos;
    Vector3 _enemyPos;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();

        switch (_balleID)
        {
            case 0:
                {
                    inputHorizontal = Input.GetAxis("Fire1");
                    inputVertical = Input.GetAxis("Fire2");

                }
                break;
            case 2:
                {
                    inputHorizontal = _randomdir[Random.Range(0, _randomdir.Length)];
                    inputVertical = _randomdir[Random.Range(0, _randomdir.Length)];
                }
                break;
        }




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

            switch (_balleID)
            {
                case 0:
                    {
                        if (inputHorizontal != 0 || inputVertical != 0)
                        {
                            transform.Translate(new Vector3(inputHorizontal, inputVertical, 0f) * Time.deltaTime * _vitesse);
                        }
                    }
                    break;
                case 2:
                    {
                        if (inputHorizontal != 0 || inputVertical != 0)
                        {
                            transform.Translate(new Vector3(inputHorizontal, inputVertical, 0f) * Time.deltaTime * _vitesse);
                        }
                        else
                        {
                            inputHorizontal = _randomdir[Random.Range(1, _randomdir.Length)];
                            inputVertical = _randomdir[Random.Range(1, _randomdir.Length)];
                        }
                    }
                    break;
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
