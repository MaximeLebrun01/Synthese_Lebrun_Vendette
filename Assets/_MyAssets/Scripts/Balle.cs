using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{

    float inputHorizontal;
    float inputVertical;

    [SerializeField] private float _vitesse = 5f;
    // Start is called before the first frame update
    void Start()
    {
        inputHorizontal = Input.GetAxis("Fire1");
        inputVertical = Input.GetAxis("Fire2");
    }

    // Update is called once per frame
    void Update()
    {

        if (inputHorizontal != 0 || inputVertical != 0)
        {
            transform.Translate(new Vector3(inputHorizontal, inputVertical, 0f) * Time.deltaTime * _vitesse);

        }

        if (transform.position.x > 4.5f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -4.5f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > 4f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -4f)
        {
            Destroy(gameObject);
        }
    }
}
