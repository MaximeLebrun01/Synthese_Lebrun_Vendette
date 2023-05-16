using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionMusiqueFond : MonoBehaviour
{
    private AudioSource _audioSource;


    private void Awake()
    {
        int nbMusiquedeFond = FindObjectsOfType<GestionMusiqueFond>().Length;
        if (nbMusiquedeFond > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {

        _audioSource = FindObjectOfType<GestionMusiqueFond>().GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Muted") == 0)
        {
            _audioSource.Stop();
        }

    }

    public void MusiqueOnOff()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            _audioSource.Play();
            PlayerPrefs.SetInt("Muted", 1);
            PlayerPrefs.Save();
        }
        else
        {
            _audioSource.Pause();
            PlayerPrefs.SetInt("Muted", 0);
            PlayerPrefs.Save();
        }
    }
}
