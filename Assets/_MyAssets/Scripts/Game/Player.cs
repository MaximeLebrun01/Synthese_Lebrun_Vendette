using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _footstepRate = 0.3f;
    [SerializeField] private float _speedPU = 1.5f;
    [SerializeField] private GameObject _balle = default;
    [SerializeField] private GameObject _randomBalle = default;
    [SerializeField] private GameObject _balleContainer = default;
    [SerializeField] private GameObject _barreVie = default;
    [SerializeField] private AudioClip _balleSound = default;
    [SerializeField] private AudioClip _footSound = default;

    private float _canfire = -1f;
    private float _CandenceInitial;
    private float _canFootSound = -1f;
    private float _ViesJoueur = 3f;
    private float _speedInitial;
    private bool _isRandom = false;
    private Animator _animTop;
    private Animator _animLeg;
    private GameManager _gestionJeu;

    public bool IsRandom { get => _isRandom; set => _isRandom = value; }


    // Start is called before the first frame update
    void Start()
    {
        _gestionJeu = FindObjectOfType<GameManager>();
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
                AudioSource.PlayClipAtPoint(_balleSound, Camera.main.transform.position, 0.3f);
                if(!_isRandom)
                {
                    GameObject newBalle = Instantiate(_balle, transform.position, Quaternion.identity);
                    newBalle.transform.parent = _balleContainer.transform;
                }
                else
                {
                    GameObject newBalle = Instantiate(_randomBalle, transform.position, Quaternion.identity);
                    newBalle.transform.parent = _balleContainer.transform;
                }
                
            }

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
            if (Time.time > _canFootSound)
            {
                _canFootSound = Time.time + _footstepRate;
                AudioSource.PlayClipAtPoint(_footSound, Camera.main.transform.position, 0.3f);

            }
        }
        else
        {
            _animLeg.SetBool("isRunning", false);
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

    public void Damage()
    {
        _ViesJoueur -= 1f;
        _barreVie.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (_ViesJoueur * 250));

        if (_ViesJoueur < 1)
        {
            SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
            spawnManager.FinPartie();
            DestructionPlayer();
            _gestionJeu.FinPartie();
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

    public void PUVie()
    {
        if (_ViesJoueur < 3f)
        {
            _ViesJoueur += 1f;
            _barreVie.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (_ViesJoueur * 250));
        }
    }

    public void PURandom()
    {
        _isRandom = true;
        _fireRate = _CandenceInitial / 2;

        StartCoroutine(PURandomCoroutine());
    }

    IEnumerator PURandomCoroutine()
    {
        yield return new WaitForSeconds(8);
        _isRandom = false;
        _fireRate = _CandenceInitial;

    }

    IEnumerator RafaleCoroutine()
    {
        yield return new WaitForSeconds(6);
        _fireRate = _CandenceInitial;
    }

    IEnumerator SpeedCoroutine()
    {
        yield return new WaitForSeconds(8);
        _speed = _speedInitial;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BalleEnemy")
        {
            Destroy(collision.gameObject);
            Damage();
        }
    }
}
