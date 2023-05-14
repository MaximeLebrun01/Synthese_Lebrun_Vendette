using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionInstructions : MonoBehaviour
{
    [SerializeField] private GameObject _menuIstruction = default;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _menuIstruction.SetActive(false);
        }
    }

    public void Instruction()
    {
        _menuIstruction.SetActive(true);
    }

    public void CloseInstruction()
    {
        _menuIstruction.SetActive(false);
    }
}
