using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField] private float _speed = 2f;
    [SerializeField] private GameObject _balle = default;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private GameObject _balleContainer = default;
    [SerializeField] private GameObject _barreVie = default;
    [SerializeField] private float _speedPU = 1.5f;

    private float _canfire = -1f;
    private float _CandenceInitial;
    private float _ViesJoueur = 3f;
    private float _speedInitial;
    private Animator _animTop;
    private Animator _animLeg;

    // Start is called before the first frame update
    void Start()
    {
        _CandenceInitial = _fireRate;
        _speedInitial = _speed;
        _animTop = transform.Find("PlayerTop").GetComponent<Animator>();
        _animLeg = transform.Find("PlayerLeg").GetComponent<Animator>();
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
        GestionFireAnim(inputHorizontal, inputVertical);
        if (Time.time > _canfire)
        {
            _canfire = Time.time + _fireRate;
            if (inputHorizontal != 0 || inputVertical != 0)
            {
                GameObject newBalle = Instantiate(_balle, transform.position, Quaternion.identity);
                newBalle.transform.parent = _balleContainer.transform;
            }

        }

    }

    private void GestionFireAnim(float inputHorizontal, float inputVertical)
    {
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

    private void MouvementJoueur()
    {
        float posHorizontal = Input.GetAxis("Horizontal");
        float posVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(posHorizontal, posVertical, 0f);

        transform.Translate(direction * Time.deltaTime * _speed);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.7f, 3.7f), Mathf.Clamp(transform.position.y, -3.2f, 3.25f), 0f);

        if (posHorizontal != 0 || posVertical != 0)
        {
            _animLeg.SetBool("isRunning", true);
        }
        else
        {
            _animLeg.SetBool("isRunning", false);
        }
    }

    public void Damage()
    {
        _ViesJoueur -= 1f;
        _barreVie.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (_ViesJoueur * 250));

        if (_ViesJoueur < 1)
        {
            SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
            spawnManager.FinPartie();
            DestructionPlayer();

        }

    }

    private void DestructionPlayer()
    {
        Destroy(gameObject);
    }

    public void PUSpeed()
    {
        _speed = _speedInitial * _speedPU;
        StartCoroutine(SpeedCoroutine());
    }

    public void PURafale()
    {
        _fireRate = _CandenceInitial / 4;
        StartCoroutine(RafaleCoroutine());
    }

    IEnumerator RafaleCoroutine()
    {
        yield return new WaitForSeconds(12);
        _fireRate = _CandenceInitial;
    }

    IEnumerator SpeedCoroutine()
    {
        yield return new WaitForSeconds(16);
        _speed = _speedInitial;
    }
}
