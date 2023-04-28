using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField] private float _speed = 1.6f;
    [SerializeField] private GameObject _balle = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouvementJoueur();
        Tir();
    }

    private void Tir()
    {
        float inputHorizontal = Input.GetAxis("Fire1");
        float inputVertical = Input.GetAxis("Fire2");
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            Instantiate(_balle, transform.position + new Vector3(inputHorizontal, 0f, 0f), Quaternion.identity);
        }

        
    }

    private void MouvementJoueur()
    {
        float posHorizontal = Input.GetAxis("Horizontal");
        float posVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(posHorizontal, posVertical, 0f);

        direction.Normalize();

        transform.Translate(direction * Time.deltaTime * _speed);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.2f, 4.2f), Mathf.Clamp(transform.position.y, -3.38f, 4.12f), 0f);

        if (transform.position.x >= 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0f);
        }
        else if (transform.position.x <= -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0f);
        }
    }
}
