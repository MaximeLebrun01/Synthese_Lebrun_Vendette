using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Balle : MonoBehaviour
{

    float inputHorizontal;
    float inputVertical;
    Player _player;

    [SerializeField] private float _vitesse = 5f;
    [SerializeField] private string _nom = default;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        inputHorizontal = Input.GetAxis("Fire1");
        inputVertical = Input.GetAxis("Fire2");
    }

    // Update is called once per frame
    void Update()
    {
        if (_nom == "Player")
        {
            LaserJoueur();
        }
        else
        {
            Vector3 direction = _player.transform.position ;
            transform.Translate(direction * Time.deltaTime * _vitesse);
        }

        DestructionGameObject();
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

    private void LaserJoueur()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            transform.Translate(new Vector3(inputHorizontal, inputVertical, 0f) * Time.deltaTime * _vitesse);

        }
    }
}
