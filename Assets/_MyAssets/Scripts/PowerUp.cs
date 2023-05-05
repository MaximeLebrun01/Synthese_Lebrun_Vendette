using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // _powerUpID 0=speed 1=rafale
    [SerializeField] private int _powerUpID = default;
    Player _playerPrefab;

    void Start()
    {
        _playerPrefab = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            Destroy(this.gameObject);
            if (player != null)
            {
                switch (_powerUpID)
                {
                    case 0:
                        player.PUSpeed();
                        break;
                    case 1:
                        player.PURafale();
                        break;
                    case 2:
                        
                        break;
                }
            }

        }
    }
}
