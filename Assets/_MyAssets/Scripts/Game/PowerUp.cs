using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // _powerUpID 0=speed 1=rafale 2=vie 3=ChangeControl
    [SerializeField] private int _powerUpID = default;

    void Start()
    {
        Destroy(gameObject, 10f);
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
                        player.PUVie();
                        break;
                    case 3:
                        player.PURandom();
                        break;
                }
            }

        }
    }
}
