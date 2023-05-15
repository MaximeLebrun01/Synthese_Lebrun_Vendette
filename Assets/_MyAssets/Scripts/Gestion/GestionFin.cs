using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GestionFin : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _txtPts = default;
    [SerializeField] private TextMeshProUGUI _txtBestPts = default;
    [SerializeField] private GameObject _displayBestPts = default;
    [SerializeField] private GameObject _inputNom = default;
    [SerializeField] private Text _inputText = default;

    private int _pts;
    private int _bestPts;
    private string _nom;


    // Start is called before the first frame update
    void Start()
    {
        _inputNom.SetActive(false);
        _displayBestPts.SetActive(false);

        _pts = PlayerPrefs.GetInt("pts");
        _txtPts.text =_pts.ToString() + " pts";

        if (_pts > PlayerPrefs.GetInt("_bestPts",0))
        {
            PlayerPrefs.SetInt("_bestPts", _pts);
            InputNom();

        }
        else
        {
            _displayBestPts.SetActive(true);

            _bestPts = PlayerPrefs.GetInt("_bestPts");
            _nom = PlayerPrefs.GetString("nom");
            _txtBestPts.text = _nom.ToString() + " :" + _bestPts.ToString() + " pts";
        }


    }

    public void DisplayBestPts()
    {
        _displayBestPts.SetActive(true);
    }

    public void InputNom()
    {
        _displayBestPts.SetActive(false);
        _inputNom.SetActive(true);
    }

    public void NomPlayerPref()
    {
        PlayerPrefs.SetString("nom", _inputText.text);
        PlayerPrefs.Save();
    }



}
