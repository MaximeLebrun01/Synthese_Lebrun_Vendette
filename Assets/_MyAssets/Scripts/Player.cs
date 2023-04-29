using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField] private float _speed = 2f;
    [SerializeField] private GameObject _balle = default;
    [SerializeField] private float _fireRate = 0.5f;

    private float _canfire = -1f;
    private float _CandenceInitial = -1f;
    private Animator _animTop;
    private Animator _animLeg;

    // Start is called before the first frame update
    void Start()
    {
        _CandenceInitial = _fireRate;
        _animTop = transform.Find("PlayerTop").GetComponent<Animator>();
        _animLeg = transform.Find("PlayerLeg").GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MouvementJoueur();
        Tir();
    }

    private void Tir()
    {
        if (Time.time > _canfire)
        {
            _canfire = Time.time + _fireRate;
            float inputHorizontal = Input.GetAxis("Fire1");
            float inputVertical = Input.GetAxis("Fire2");
            if (inputHorizontal != 0 || inputVertical != 0)
            {
                Instantiate(_balle, transform.position, Quaternion.identity);
            }

            if (inputHorizontal == 1)
            {
                _animTop.SetBool("FireRight", true);
            }
            else
            {
                _animTop.SetBool("FireRight", false);
            }

            if (inputHorizontal == -1)
            {
                _animTop.SetBool("FireLeft", true);
            }
            else
            {
                _animTop.SetBool("FireLeft", false);
            }

            if (inputVertical == 1)
            {
                _animTop.SetBool("FireBack", true);
            }
            else
            {
                _animTop.SetBool("FireBack", false);
            }

            if (inputVertical == -1)
            {
                _animTop.SetBool("FireFace", true);
            }
            else
            {
                _animTop.SetBool("FireFace", false);
            }

        }
        
    }

    private void MouvementJoueur()
    {
        float posHorizontal = Input.GetAxis("Horizontal");
        float posVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(posHorizontal, posVertical, 0f);

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

        if (posHorizontal != 0 || posVertical != 0)
        {
            _animLeg.SetBool("isRunning", true);
        }
        else
        {
            _animLeg.SetBool("isRunning", false);
        }
    }
}
