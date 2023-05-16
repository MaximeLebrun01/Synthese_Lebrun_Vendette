using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionMusiqueFond : MonoBehaviour
{

    [SerializeField] private GameObject _btnMutePrefab = default;
    [SerializeField] private Sprite _muted = default;
    [SerializeField] private Sprite _notMuted = default;

    private AudioSource _audioSource;

    private void Start()
    {

        _audioSource = FindObjectOfType<MusiqueFond>().GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Muted") == 0)
        {
            _btnMutePrefab.GetComponent<Image>().sprite = _muted;
            _audioSource.Stop();
        }
        else
        {
            _btnMutePrefab.GetComponent<Image>().sprite = _notMuted;
        }

    }

    public void MusiqueOnOff()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            _btnMutePrefab.GetComponent<Image>().sprite = _notMuted;
            _audioSource.Play();
            PlayerPrefs.SetInt("Muted", 1);
            PlayerPrefs.Save();
        }
        else
        {
            _btnMutePrefab.GetComponent<Image>().sprite = _muted;
            _audioSource.Pause();
            PlayerPrefs.SetInt("Muted", 0);
            PlayerPrefs.Save();
        }
    }
}
