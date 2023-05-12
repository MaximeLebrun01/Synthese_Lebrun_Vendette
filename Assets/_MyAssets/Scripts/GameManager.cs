using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int _pointage;
    private float _temps = 0;

    public int Pointage { get => _pointage; set => _pointage = value; }
    public float Temps { get => _temps; set => _temps = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Méthodes public
    public void AugmenterPointage(int pts)
    {
        Pointage +=pts;
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ChangerPointage(Pointage);
    }
}
