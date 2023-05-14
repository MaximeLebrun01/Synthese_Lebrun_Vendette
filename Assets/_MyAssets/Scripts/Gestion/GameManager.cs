using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int _pointage;
    private float _temps = 0;

    public int Pointage { get => _pointage; set => _pointage = value; }
    public float Temps { get => _temps; set => _temps = value; }

    public void FinPartie()
    {
        PlayerPrefs.SetInt("pts", Pointage);
        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
    }

    // Méthodes public
    public void AugmenterPointage(int pts)
    {
        Pointage +=pts;
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ChangerPointage(Pointage);
    }


}
