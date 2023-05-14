using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txtPts = default;
    [SerializeField] private TextMeshProUGUI _txtTemps = default;
    [SerializeField] private GameObject _menuPause = default;
    [SerializeField] private bool _enPause;


    void Start()
    {
        EnleverPause();
        _txtPts.text = "0 Pts";
    }


    private void Update()
    {

        _txtTemps.text = (Time.timeSinceLevelLoad).ToString("f2") + " Secondes";
        GestionPause();
    }




    private void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            EnleverPause();
        }
    }

    public void ChangerPointage(int p_pointage)
    {
        _txtPts.text = p_pointage.ToString() + " Pts";
    }

    public void EnleverPause()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
    }
}
