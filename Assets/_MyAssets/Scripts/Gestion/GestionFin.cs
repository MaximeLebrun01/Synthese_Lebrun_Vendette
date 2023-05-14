using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestionFin : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _txtPts = default;
    [SerializeField] private TextMeshProUGUI _txtBestPts = default;

    private int _pts;
    private int _bestPts;


    // Start is called before the first frame update
    void Start()
    {
        _pts = PlayerPrefs.GetInt("pts");
        _txtPts.text =_pts.ToString() + " pts";

        if (_pts > PlayerPrefs.GetInt("_bestPts",0))
        {
            PlayerPrefs.SetInt("_bestPts", _pts);
            PlayerPrefs.Save();
        }

        _bestPts = PlayerPrefs.GetInt("_bestPts");
        _txtBestPts.text = "________ :" +_bestPts.ToString() + " pts";
    }
}
